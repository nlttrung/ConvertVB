using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ConvertTool
{
    public class CodeReplace
    {
        private List<Node> rule;
        private List<string> code;

        public CodeReplace()
        {
            rule = new List<Node>();
            code = new List<string>();
        }

        private String getRuleSplitStr()
        {
            List<string> tmp = rule.Where(x => !String.IsNullOrEmpty(x.Value))
                .Select(x => "(" + x.Value.Replace(")", "\\)").Replace("(", "\\(") + ")").ToList();
            String result = String.Join("|", tmp);
            return @result;
        }

        private List<string> getRuleSplitList()
        {
            List<string> tmp = rule.Where(x => !String.IsNullOrEmpty(x.Value))
                .Select(x => x.Value).ToList();
            return tmp;
        }

        private void parseRule(string strRule)
        {
            //parse rule
            string pattern = @"(\$)";
            List<string> tmp = Regex.Split(strRule, pattern).ToList();

            foreach (String s in tmp)
            {
                Node r = new Node();
                if (!String.IsNullOrEmpty(s.Trim()))
                {
                    r.input(s.Trim());
                }
                rule.Add(r);
            }
        }

        private void parseCode(string strCode)
        {
            //parse code
            String[] codeItems = Regex.Split(strCode, this.getRuleSplitStr());
            List<string> listRuleNodes = this.getRuleSplitList();
            foreach (string str in codeItems)
            {
                String s = str.Trim();
                if (!listRuleNodes.Contains(s))
                {
                    string pattern = @"([A-z]+\([^)]*\))|(\([^)]*\))|( )|(\()";
                    List<string> tmp = Regex.Split(s, pattern).ToList();
                    this.code.AddRange(tmp.Where(x => !String.IsNullOrEmpty(x.Trim())));
                }
                else
                {
                    this.code.Add(s);
                }
            }
        }

        public string convertCode(String strRule, string strCode, ref bool hasChanged)
        {
            hasChanged = false;
            rule.Clear();
            code.Clear();

            if (strCode.StartsWith("'")) return strCode;

            this.parseRule(strRule);
            this.parseCode(strCode);

            Converter cv = new Converter(rule, code);
            return cv.Convert(ref hasChanged);
        }
    }

    public class Node
    {
        private String value;
        private String newValue;

        public string Value { get => value; set => this.value = value; }
        public string NewValue { get => newValue; set => newValue = value; }

        public Node() { }

        #region public Boolean input(String val)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public Boolean input(String val)
        {
            //parse rule
            String[] sep = { "@" };
            String[] arr = val.Split(sep, StringSplitOptions.None);

            if (arr.Length == 1)
            {
                value = arr[0].Trim();
                return true;
            }

            if (arr.Length == 2)
            {
                value =  String.IsNullOrEmpty(arr[0]) ?  "" : arr[0].Trim();
                newValue = arr[1].Trim();
                return true;
            }

            return false;
        } 
        #endregion
    }

    public class NodeCode
    {
        public string value { get; set; }
        public Node rule { get; set; }

        public NodeCode(string val)
        {
            this.value = val;
        }
    }

    public class Converter
    {
        private List<Node> rule;
        private List<NodeCode> node = new List<NodeCode>();

        public Converter(List<Node> rule, List<string> code)
        {
            this.rule = rule;
            foreach(string str in code)
            {
                this.node.Add(new NodeCode(str));
            }
        }

        public string Convert(ref bool hasChanged)
        {
            hasChanged = false;
            for (int i = 0; i < node.Count; i++)
            {
                for (int j = 0; j < rule.Count; j++)
                {
                    int z = i + j;
                    if (z >= node.Count) break;

                    if (String.IsNullOrEmpty(rule[j].Value) || rule[j].Value == "$" || rule[j].Value == node[z].value)
                    {
                        node[z].rule = rule[j];

                        if (j == rule.Count - 1)
                        {
                            //convert code;
                            for (int w = z; w >= i; w--)
                            {
                                if (node[w].value == node[w].rule.Value)
                                    node[w].value = node[w].rule.NewValue;
                                else if (String.IsNullOrEmpty(node[w].rule.Value))
                                    node[w].value += node[w].rule.NewValue;

                                node[w].rule = null;
                            }
                            hasChanged = true;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return String.Join("", node.Select(x => x.value).ToList());
        }

    }
}
