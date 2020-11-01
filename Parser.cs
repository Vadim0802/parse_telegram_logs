using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

/*
 |Системный номер|name|fname|phone|uid|nik|wo|
 |1|random_name0|random_fname0|random_phone0|928641057|WeB_BackenD|0118532866300
 */

namespace Parser_Logs
{
    public static class Parser
    {
        public static IEnumerable<string> Find(string nickName, string path)
        {
            var logs = new List<string>();
            try
            {
                using var reader = new StreamReader(path);
                
                string info = "";
                while ((info = reader.ReadLine()) != null)
                {
                    var line = FormattingLog(info);

                    if (IsCorrectLog(line))
                        if ((line.ElementAt(5))== nickName)
                            logs.Add(info);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Something Wrong!");
            }

            return logs;
        }
        
        private static IEnumerable<string> FormattingLog(string info)
        {
            return info.Substring(1).Split('|').ToList();
        }

        private static bool IsCorrectLog(IEnumerable<string> info)
        {
            if (info.Count() != 7)
                return false;

            int emptyField = info
                .Where((item => item == " "))
                .Count();

            if (emptyField > 0)
                return false;

            return true;
        }
    }    
}