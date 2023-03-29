using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgFund_08._03
{
    public class Campaign
    {
        public List<string> files;
        public int crtLevel;
        public Campaign()
        {
            crtLevel = 0;
            files = new List<string>();
            files.Add("Map1.txt");
            files.Add("Map2.txt");
            files.Add("Map3.txt");
            files.Add("Map4.txt");
        }
        public string GetCurrentFile()
        {
            return files[crtLevel];
        }
    }
}
