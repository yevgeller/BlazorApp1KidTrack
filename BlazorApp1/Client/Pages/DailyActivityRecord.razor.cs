using BlazorApp1.FakeDAL2;
using BlazorApp1.Shared.Models;
using BlazorApp1.Shared.Models.DailyActivityReport;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Client.Pages
{
    public partial class DailyActivityRecord
    {
        MainDAL mainDAL;
        Person student;
        //Hashtable selectedMessages;
        List<StatusMessage> selectedMessages;
        Hashtable messageTypes;

        [Parameter]
        public int StudentId { get; set; }

        [Inject]
        NavigationManager nm { get; set; }

        DateTime groupActivityDateVar;
        DateTime groupActivityTimeVar;
        public string GroupActivityDate
        {
            get
            {
                return groupActivityDateVar.ToString("ddd d MMM");
            }
            private set { }
        }
        public string GroupActivityTime
        {
            get
            {
                return groupActivityTimeVar.ToString("h:mm");
            }
            private set { }
        }
        public bool TooFarInTheFuture()
        {
            if (DateTime.Now.AddDays(7) < groupActivityDateVar)
                return true;

            return false;
        }
        public bool TooFarInThePast()
        {
            if (DateTime.Now.AddDays(-7) > groupActivityDateVar)
                return true;

            return false;
        }

        public void ResetDate()
        {
            groupActivityDateVar = DateTime.Now;
            groupActivityTimeVar = DateTime.Now;
        }
        public void PrevDay()
        {
            var dayOfWeek = groupActivityDateVar.DayOfWeek;
            int increment = -1;
            if (dayOfWeek == DayOfWeek.Monday)
            {
                increment = -3;
            }
            groupActivityDateVar = groupActivityDateVar.AddDays(increment);
        }
        public void NextDay()
        {
            var dayOfWeek = groupActivityDateVar.DayOfWeek;
            int increment = 1;
            if (dayOfWeek == DayOfWeek.Friday)
            {
                increment = 3;
            }
            groupActivityDateVar = groupActivityDateVar.AddDays(increment);
        }
        public void ChangeMinutes(int increment)
        {
            groupActivityTimeVar = groupActivityTimeVar.AddMinutes(increment);
        }
        private void AdjustMessage(int code)
        {
            if (selectedMessages.Where(x => x.Code == code).Any())
            {
                selectedMessages.RemoveAll(x => x.Code == code);
            }
            else
            { add type
                    fix message
                if (code >= 10 && code < 20)
                {
                    selectedMessages.RemoveAll(x => x.Code >= 10 && x.Code < 20);
                }
                else if (code >= 20 && code < 30)
                {
                    selectedMessages.RemoveAll(x => x.Code >= 20 && x.Code < 30);
                }
                else if (code >= 30 && code < 40)
                {
                    selectedMessages.RemoveAll(x => x.Code >= 30 && x.Code < 40);
                }
                else if (code >= 40 && code < 50)
                {
                    selectedMessages.RemoveAll(x => x.Code >= 40 && x.Code < 50);
                }
                SaveMessage(code);
            }
        }
        private void SaveMessage(int code)
        {
            selectedMessages.Add(new StatusMessage
            {
                Code = code,
                Message = (string)messageTypes[code]
            });
        }

        public string ProposedMessage
        {
            get
            {
                if (selectedMessages.Count() == 0)
                    return "N/A";

                return String.Join("; ", selectedMessages);
                //string result = "";
                //foreach (string s in selectedMessages.Values)
                //{
                //    result += s + "; ";
                //}
                //return result;
            }
        }
        protected override void OnParametersSet()
        {
            StudentId = StudentId;
            base.OnParametersSet();
        }
        protected override void OnInitialized()
        {
            mainDAL = new MainDAL();
            student = mainDAL.GetPersonById(StudentId);
            groupActivityDateVar = DateTime.Now;
            groupActivityTimeVar = DateTime.Now;
            selectedMessages = new List<StatusMessage>(); //new Hashtable();
            GenerateHashTableOfMessages();
            base.OnInitialized();
        }

        private void GenerateHashTableOfMessages()
        {
            messageTypes = new Hashtable();
            messageTypes.Add(10, "Dirty Diaper");
            messageTypes.Add(11, "Wet Diaper");
            messageTypes.Add(12, "Clean Diaper");

            //messageTypes.Add(20, "Ate all breakfast");
            messageTypes.Add(21, "Refused breakfast");
            messageTypes.Add(22, "Ate very little breakfast");
            messageTypes.Add(23, "Ate about half of breakfast");

            messageTypes.Add(31, "Refused lunch");
            messageTypes.Add(32, "Ate very little lunch");
            messageTypes.Add(33, "Ate about half of lunch");

            messageTypes.Add(41, "Refused snack");
            messageTypes.Add(42, "Ate very little snack");
            messageTypes.Add(43, "Ate about half of snack");

            messageTypes.Add(51, "No nap");
            messageTypes.Add(52, "Slept 30 min");
            messageTypes.Add(53, "Slept 1 hour");
            messageTypes.Add(54, "Slept 1.5 hours");

            messageTypes.Add(61, "Need wipes");
            messageTypes.Add(62, "Need diaper cream");
            messageTypes.Add(63, "Need diapers");
        }
    }
}
