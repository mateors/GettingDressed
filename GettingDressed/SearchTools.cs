using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace GettingDressed
{
    class SearchTools
    {
        //enum TempType { HOT, COLD};


        public string commandToDescription(string commaSeparatedCmdString, List<NumericCommand> ncList)
        {

            string cmdOutput = "";
            string tempType = "";
            string command = "";


            Regex regex = new Regex(@"^(\w+)(.*)");
            Match match = regex.Match(commaSeparatedCmdString);
            if (match.Success)
            {
                tempType = match.Groups[1].Value;
                command = match.Groups[2].Value.Trim(',');
            }

            List<string> cmdList = command.Split(',').ToList();
            foreach (string cmd in cmdList)
            {
                var isNumeric = int.TryParse(cmd, out var n);
                if (isNumeric)
                {




                    if (tempType == "HOT")
                        cmdOutput += ncList.Single(c => c.command == n).hotResponse + ",";

                    if (tempType == "COLD")
                        cmdOutput += ncList.Single(c => c.command == n).coldResponse + ",";

                }

            }

            return cmdOutput.TrimEnd(',');
        }



        //Taking searchString and pattern as input and string List as output
        public List<string> searchPattern(string searchString, string pattern)
        {
            List<string> result = new List<string>();

            //@"(\w+) (\d+)";
            Regex regex = new Regex(pattern);
            Match match = regex.Match(searchString);

            if (match.Success)
            {
                for (int i = 0; i < match.Groups.Count; i++)
                {
                    result.Add(match.Groups[i].Value);
                }

            }
            return result;
        }

        //checking success pattern in successPatternList
        public bool FindSuccess(string searchString, List<string> successPatternList)
        {
            List<string> errorList = new List<string>();

            foreach (string pattern in successPatternList)
            {

                //Console.WriteLine("String: "+ searchString+ " P: " + pattern);

                List<string> outPut = searchPattern(searchString, pattern.Trim());
                if (outPut.Count > 0)
                {

                    return true;
                }
                else
                {
                    errorList.Add("error exist");
                    //Console.WriteLine("ERROR ==>"+searchString+" Pat:"+pattern);

                }

            }

            if (errorList.Count == 0) { return true; }

            return false;

        }
    }
}
