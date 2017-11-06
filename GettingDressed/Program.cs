using System;
using System.Collections.Generic;


namespace GettingDressed
{
    class Program
    {
       

        static void Main(string[] args)
        {
            ConsoleKeyInfo cki;
            List<string> successPatternList = new List<string>();


            string line;
            int counter = 0;

            System.IO.StreamReader file = new System.IO.StreamReader("success_pattern.txt"); //@"c:\test.txt"
            while ((line = file.ReadLine()) != null)
            {
                
                if (line.Length > 2)
                {
                    //System.Console.WriteLine(line);
                    successPatternList.Add(line.Trim());
                }
                
                counter++;
            }

            file.Close();
            file.Dispose();

            List<NumericCommand> ncList = new List<NumericCommand> {

                new NumericCommand { command=1, description="Put on footwear", hotResponse="sandals",  coldResponse="boots"},
                new NumericCommand { command=2, description="Put on headwear", hotResponse="sunglasses", coldResponse="hat"},
                new NumericCommand { command=3, description="Pun on socks", hotResponse="fail", coldResponse="socks"},
                new NumericCommand { command=4, description="Put on shirt", hotResponse="shirt", coldResponse="shirt"},
                new NumericCommand { command=5, description="Put on jacket", hotResponse="fail", coldResponse="jacket"},
                new NumericCommand { command=6, description="Put on pants", hotResponse="shorts", coldResponse="pants"},
                new NumericCommand {command=7, description="Leave house", hotResponse="leave house", coldResponse="leave house"},
                new NumericCommand {command=8, description="Take off pajamas", hotResponse="Removing PJs", coldResponse="Removing PJs"}

            };

            

            //using (System.IO.StreamReader r = new StreamReader("database.json"))//json
            //{
            //    string json = r.ReadToEnd();
            //    ncList = JsonConvert.DeserializeObject<List<NumericCommand>>(json);

            //}


            //Console.WriteLine(""+ncList.Count);

            //foreach(string s in successPatternList)
            //{
            //    Console.WriteLine(">"+s);
            //}

            //Console.Clear();
            Console.WriteLine("Input your Alpha-Numeric codes for getting dressed for the day.");


            var con = true;
            int n = 0;
            var inputString = "";
            while (con == true)
            {

                SearchTools st = new SearchTools();

                cki = Console.ReadKey(true);
                inputString += cki.KeyChar.ToString();

                // Exit if the user pressed the 'X' key. 
                if (cki.Key == ConsoleKey.X) break;
                Console.Clear();
                Console.WriteLine("Input: "+inputString.ToUpper());

                string output = "";

                if (cki.Key == ConsoleKey.Enter)
                {
                    bool succ = st.FindSuccess(inputString.ToUpper(), successPatternList);
                    //Console.WriteLine("Res:->" + succ.ToString());
                    if (succ == true) { Console.WriteLine("FAIL"); break; }
                    if (succ == false) { Console.WriteLine("CONGRATULATIONS! SUCCESSFULLY DRESSED UP! :-)"); break; }
                }

                try
                {
                    
                    bool succ = st.FindSuccess(inputString.ToUpper(), successPatternList);
                    output=st.commandToDescription(inputString.ToUpper(), ncList);
                    //Console.WriteLine("Res:->" + succ.ToString());
                    Console.WriteLine("Output: "+output);
                    if (succ == false) { Console.WriteLine("fail"); break; }

                }catch(Exception ce)
                {
                    // Console.WriteLine("Error: "+ce.Message);
                    Console.WriteLine("fail");
                }

                n++;
            }


    }



        
    }



}