using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



    public class UserData
    {
    public UserData(string username, int totalCount, int winCount) {
        this.Username = username;
        this.TotalCount = totalCount;
        this.WinCount = winCount;
    }
        public string Username { get;private set; }
        public int TotalCount { get; private set; }
        public int WinCount { get; private set; }
    }

