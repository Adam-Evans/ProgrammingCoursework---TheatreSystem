using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheatreSystem08220.CS
{
    
    public enum accessLevel { Admin, Manager, CustomerRep, NewsletterEditor, BookingOfficer};

    public class Staff
    {
        private string loginName;
        private string loginPassword;
        private accessLevel access;

        public Staff(string pLoginName, string pLoginPass, accessLevel pAccess) {
            loginName = pLoginName;
            loginPassword = pLoginPass;
            access = pAccess;

        }

        public string getLogin() {
            return loginName;
        }

        //no string return for password for obvious reasons. Clearly a much better encryption method would be used here but that is not our task. 
        public bool checkPassword() {
            //check for password script here, not yet implemented. 
            return true;
        }

        //used for debugging reasons to check an accounts level of access to certain features. 
        public string getAccessLevel() {
            return access.ToString();
        }

        public void saveStaff(Staff pStaff)
        {

        }
    }

    
}
