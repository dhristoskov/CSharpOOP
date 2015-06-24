using System;
using System.Collections.Generic;

namespace MyTunesShop
{
    public class Band : Performer , IBand
    {
        private IList<string> members; 
        public Band(string name) : base(name)
        {
        }

        public override PerformerType Type
        {
            get
            {
                return PerformerType.Band;
            }
        }

        public IList<string> Members
        {
            get
            {
                if (this.members == null)
                {
                    this.members = new List<string>();
                }
                return this.members;
            }
        }

        public void AddMember(string memberName)
        {
            this.members.Add(memberName);
        }
    }
}
