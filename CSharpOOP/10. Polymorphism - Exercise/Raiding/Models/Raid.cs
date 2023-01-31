using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace Raiding.Models
{
    public class Raid : IEnumerable
    {
		private List<BaseHero> raidMembers;
		public Raid()
		{
			this.RaidMembers = new List<BaseHero>();
		}

		public List<BaseHero> RaidMembers
        {
			get
			{
				return raidMembers;
			}
			set
			{
				
				raidMembers = value; 
			}
		}
		public int Count => this.RaidMembers.Count;
		public void AddRaidMemeber(BaseHero hero)
		{
			this.RaidMembers.Add(hero);
        }

		public IEnumerator GetEnumerator()
		{
			for (int i = 0; i < this.RaidMembers.Count; i++)
			{
				yield return this.RaidMembers[i];

			}
		}

		public int RaidPower()
		{
			return this.RaidMembers.Sum(h=>h.Power);
		}


	}
}
