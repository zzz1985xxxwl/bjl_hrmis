using System;
using System.Collections.Generic;
using System.Text;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter
{
    public class TemplatePaperUtility
    {
        public static ItemClassficationEmnu GetChoosedItemClassfication(string classfication)
        {
            return AssessUtility.GetChoosedItemClassfication(classfication);
        }

        public static Dictionary<string, string> GetItemClassficationEnum()
        {
           return AssessUtility.GetItemClassfication();
        }

        public static void InitOperation(IAddTemplateItemView view, AssessTemplateItem item)
        {
            switch (view.AssessTemplateItemType)
            {
                case 0:
                    item.Option = Option(view);
                    break;
                case 2:
                    item.Option = ScoreRange(view);
                    break;
                case 3:
                    item.Option = view.Formula;
                    break;
                default:
                    item.Option = string.Empty;
                    break;
            }
        }

        public static string Option(IAddTemplateItemView view)
        {
            StringBuilder sb = new StringBuilder();
            string split = "/";
            sb.Append(view.Option5);
            sb.Append(split);
            sb.Append(view.Option4);
            sb.Append(split);
            sb.Append(view.Option3);
            sb.Append(split);
            sb.Append(view.Option2);
            sb.Append(split);
            sb.Append(view.Option1);
            return sb.ToString();
        }

        public static string ScoreRange(IAddTemplateItemView view)
        {
            StringBuilder sb = new StringBuilder();
            string split = "/";
            sb.Append(view.MinRange);
            sb.Append(split);
            sb.Append(view.MaxRange);
            return sb.ToString();
        }

        public static bool Validate(IAddTemplateItemView view)
        {
            bool iRet = true;
            if (string.IsNullOrEmpty(view.Question))
            {
                view.QestionNullMessage = "请输入绩效考核项指标项描述";
                iRet = false;
            }
            switch (view.AssessTemplateItemType)
            {
                case 0:
                    iRet = ValideOption(iRet, view);
                    break;
                case 2:
                    iRet = VaildeDafen(iRet, view);
                    break;
                case 3:
                    iRet = VaildeFormula(iRet, view);
                    break;
            }
            return iRet;
        }

        private static bool VaildeDafen(bool iRet, IAddTemplateItemView view)
        {
            int inttempMax;
            int inttempMin;
            if (string.IsNullOrEmpty(view.MaxRange) || string.IsNullOrEmpty(view.MinRange))
            {
                view.RangeError = "不能为空";
                iRet = false;
            }
            else if (!Int32.TryParse(view.MaxRange, out inttempMax) || !Int32.TryParse(view.MinRange, out inttempMin))
            {
                view.RangeError = "格式错误";
                iRet = false;
            }
            else if (inttempMax < inttempMin)
            {
                view.RangeError = "范围应该从小到大";
                iRet = false;
            }
            return iRet;
        }

        private static bool VaildeFormula(bool iRet, IAddTemplateItemView view)
        {
            if (string.IsNullOrEmpty(view.Formula))
            {
                view.FormulaError = "不能为空";
                iRet = false;
            }
            else
            {
                try
                {
                    AssessUtility.CheckFormula(view.Formula);
                }
                catch
                {
                    view.FormulaError = "公式错误";
                    iRet = false;
                }
            }
            return iRet;
        }

        private static bool ValideOption(bool iRet, IAddTemplateItemView view)
        {
            if (view.Question.Length > 100)
            {
                view.QestionNullMessage = "绩效考核指标项应小于100个字符";
                iRet = false;
            }
            if (string.IsNullOrEmpty(view.Option5))
            {
                view.ItemMessage5 = "请输入分值5对应的选项";
                iRet = false;
            }
            if (string.IsNullOrEmpty(view.Option4))
            {
                view.ItemMessage4 = "请输入分值4对应的选项";
                iRet = false;
            }
            if (string.IsNullOrEmpty(view.Option3))
            {
                view.ItemMessage3 = "请输入分值3对应的选项";
                iRet = false;
            }
            if (string.IsNullOrEmpty(view.Option2))
            {
                view.ItemMessage2 = "请输入分值2对应的选项";
                iRet = false;
            }
            if (string.IsNullOrEmpty(view.Option1))
            {
                view.ItemMessage1 = "请输入分值1对应的选项";
                iRet = false;
            }
            if (view.Option5.Length >= 50)
            {
                view.ItemMessage5 = "选项应小于50个字";
                iRet = false;
            }
            if (view.Option4.Length >= 50)
            {
                view.ItemMessage4 = "选项应小于50个字";
                iRet = false;
            }
            if (view.Option3.Length >= 50)
            {
                view.ItemMessage3 = "选项应小于50个字";
                iRet = false;
            }
            if (view.Option2.Length >= 50)
            {
                view.ItemMessage2 = "选项应小于50个字";
                iRet = false;
            }
            if (view.Option1.Length >= 50)
            {
                view.ItemMessage1 = "选项应小于50个字";
                iRet = false;
            }

            if ((!string.IsNullOrEmpty(view.Option1) && !string.IsNullOrEmpty(view.Option2) &&
                 !string.IsNullOrEmpty(view.Option3) && !string.IsNullOrEmpty(view.Option4) &&
                 !string.IsNullOrEmpty(view.Option5)) &&
                (view.Option1.Length <= 50 && view.Option2.Length <= 50 && view.Option3.Length <= 50 &&
                 view.Option4.Length <= 50 && view.Option5.Length <= 50))
            {
                string[] repeat = new string[5];

                repeat[0] = view.Option5;
                repeat[1] = view.Option4;
                repeat[2] = view.Option3;
                repeat[3] = view.Option2;
                repeat[4] = view.Option1;
                for (int i = 0; i < repeat.Length; i++)
                {
                    for (int j = 0; j < repeat.Length; j++)
                    {
                        if (i != j)
                        {
                            if (repeat[i].Equals(repeat[j]))
                            {
                                view.ItemMessage1 = "选项不能重复";
                                iRet = false;
                            }
                        }
                    }
                }
            }
            return iRet;
        }
    }
}