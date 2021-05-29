using BlazorApp1.FakeDAL2;
using BlazorApp1.Shared.Models;
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
        Hashtable selectedMessages;
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
        private void SaveMessage(int messageCode)
        {
            string message = (string)messageTypes[messageCode];
            selectedMessages.Add(messageCode, messageTypes[messageCode]);
        }
        private void RemoveMessage(int messageCode)
        {
            selectedMessages.Remove(messageCode);
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
            selectedMessages = new Hashtable();
            GenerateHashTableOfMessages();
            base.OnInitialized();
        }

        private void GenerateHashTableOfMessages()
        {
            messageTypes = new Hashtable();
            messageTypes.Add(10, "Dirty Diaper");
            messageTypes.Add(11, "Wet Diaper");
            messageTypes.Add(12, "Clean Diaper");

            messageTypes.Add(20, "Ate all breakfast");
            messageTypes.Add(21, "Refused breakfast");
            messageTypes.Add(22, "Ate very little breakfast");
            messageTypes.Add(23, "Ate about half of breakfast");


        }
    }

    //public enum MessageCodes
    //{
    //    Dirty_Diaper = 10,
    //    Wet_Diaper = 11,
    //    Clean_Diaper = 12
    //}
}
