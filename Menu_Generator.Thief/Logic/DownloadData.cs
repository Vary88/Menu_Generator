using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;

using Menu_Generator.Thief.Model;

namespace Menu_Generator.Thief.Logic
{
    public class DownloadData
    {
        private DownloadData() 
        {

        }

        private static string url = "https://egeszsegkonyha.hu/index.php/etlapunk?week=2020";
        
        public static DownLoadedData Get()
        {
            SetCurrentWeek();
            List<string[]> importantData = new List<string[]>();
            List<string> tempData = new List<string>();
            using (WebClient client = new WebClient())
            {
                string data = client.DownloadString(url);
                string[] spitteredData = data.Split("<tbody>").Last().Split("</tbody>").First().Split("<tr");
                for (int i = 0; i < spitteredData.Length; i++)
                {
                    if (i == 0)
                    {
                        continue;
                    }
                    tempData.Add(spitteredData[i]);
                }
            }
            foreach (string item in tempData)
            {
                string[] tempLines = item.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                for (int i = 0; i < tempLines.Length; i++)
                {
                    if (i == 0)
                    {
                        tempLines = tempLines.Where(x => x != tempLines[i]).ToArray();
                    }
                    else if (i == tempLines.Length - 1)
                    {
                        tempLines = tempLines.Where(x => x != tempLines[i]).ToArray();
                        tempLines = tempLines.Where(x => x != tempLines[i - 1]).ToArray();
                    }
                }
                importantData.Add(tempLines);
            }

            return new DownLoadedData(importantData);
        }
        private static void SetCurrentWeek()
        {
            DateTime time = DateTime.Now;
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }
            int currentDate = CultureInfo
                .InvariantCulture
                .Calendar
                .GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            string strCurrentDate = currentDate.ToString();
            if (strCurrentDate.Length < 2)
            {
                url = url + "0" + strCurrentDate;
            }
            else
            {
                url = url + strCurrentDate;
            }
        }
    }
}
