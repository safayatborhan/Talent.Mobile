using System;
using System.Collections.Generic;

namespace Talent.Mobile.Models.State
{
    public class State
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class ResponseText
    {
        public string token { get; set; }
        public string hiremee_id { get; set; }
        public List<State> state { get; set; }
    }

    public class RootObject
    {
        public string code { get; set; }
        public string message { get; set; }
        public ResponseText responseText { get; set; }
    }
}

