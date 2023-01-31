using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{
		private List<Character> party;
		private List<Item> itemPool;


		public WarController()
		{
			this.party = new List<Character>();
			this.itemPool = new List<Item>();
		}

		public string JoinParty(string[] args)
		{
			string charType = args[0]; 
			string charName = args[1];

            Character currCharracter;
            if (charType.ToLower() == "warrior")
			{
                currCharracter = new Warrior(charName);

            }
            else if (charType.ToLower() == "priest")
			{
                currCharracter = new Priest(charName);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, charType));
            }
			party.Add(currCharracter);
			return String.Format(SuccessMessages.JoinParty, charName);

        }

		public string AddItemToPool(string[] args)
		{
			string itemType = args[0];
			Item item;
			if (itemType.ToLower() == "healthpotion")
			{
				item = new HealthPotion();

            }
			else if (itemType.ToLower() == "firepotion")
			{
                item = new FirePotion();
            }
			else
			{
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemType));
            }
			itemPool.Add(item);
			return string.Format(SuccessMessages.AddItemToPool, itemType);
		}

		public string PickUpItem(string[] args)
		{
			string charracterName = args[0];
			Character currCharacter = this.party.FirstOrDefault(c=>c.Name == charracterName);
			if (currCharacter == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, charracterName));
            }
			if (!this.itemPool.Any())
			{
				throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }
			Item lastItemInTheBag = null;
			if (this.itemPool[this.itemPool.Count-1] is HealthPotion healthPotion)
			{
				lastItemInTheBag = healthPotion;
            }
			else if (this.itemPool[this.itemPool.Count-1] is FirePotion firePotion)
			{
				lastItemInTheBag = firePotion;
            }
			else
			{
				throw new ArgumentException();
			}
			currCharacter.Bag.AddItem(lastItemInTheBag);
			this.itemPool.Remove(lastItemInTheBag);
			return string.Format(SuccessMessages.PickUpItem, charracterName, lastItemInTheBag.GetType().Name);

        }

		public string UseItem(string[] args)
		{
			string characterName = args[0];
			string itemName = args[1];

            Character currCharacter = this.party.FirstOrDefault(c => c.Name == characterName);
			if (currCharacter == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }
			else
			{
				Item itemToUse = currCharacter.Bag.GetItem(itemName);
				currCharacter.UseItem(itemToUse);
				return string.Format(SuccessMessages.UsedItem, characterName, itemName);

            }
			
        }

		public string GetStats()
		{
			StringBuilder sb = new StringBuilder();
			var sortedParty = this.party.OrderByDescending(c => c.IsAlive).ThenByDescending(c => c.Health).ToList();
			foreach (Character character in sortedParty)
			{
				string printCurrLiveState = character.IsAlive ? "Alive" : "Dead";
				sb.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: {printCurrLiveState}");
			}
			return sb.ToString().Trim();
		}

		public string Attack(string[] args)
		{
			string attackerName = args[0];
			string receiverName = args[1];

			Character attacker = this.party.FirstOrDefault(c=>c.Name == attackerName);
			if (attacker == null)
			{
				throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            }
            Character receiver = this.party.FirstOrDefault(c => c.Name == receiverName);
            if (receiver == null || !attacker.IsAlive || !receiver.IsAlive || attacker is Priest)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.AttackFail, attackerName));
            }
			StringBuilder sb = new StringBuilder();
			Warrior warrior = attacker as Warrior;
			warrior.Attack(receiver);
			sb.AppendLine($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");
			if (!receiver.IsAlive)
			{
				sb.AppendLine($"{receiver.Name} is dead!");
			}
			return sb.ToString().Trim();
        }

		public string Heal(string[] args)
		{
			string healerName = args[0];
			string healingReceiverName = args[1];

            Character healer= this.party.FirstOrDefault(c => c.Name == healerName);
            if (healerName == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, healerName));
            }
            Character receiver = this.party.FirstOrDefault(c => c.Name == healingReceiverName);
            if (receiver == null || !healer.IsAlive || !receiver.IsAlive || healer is Warrior)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.HealerCannotHeal, healerName));
            }
			Priest priste = healer as Priest;
			priste.Heal(receiver);

			return $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
        }
		
	}
}
