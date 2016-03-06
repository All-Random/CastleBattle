using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.IO;
using CastleBattle.Armory;
using System.Collections.Generic;

namespace CastleBattle.Armory
{
	public class WeaponRepositoryImp : MonoBehaviour, WeaponRepository
	{
		private IDictionary<string, Weapon> weapons;

		public WeaponRepositoryImp ()
		{
			weapons = new SortedList<string, Weapon> ();
		}

		public void Save (Weapon weapon)
		{
			weapons.Add (weapon.Id, weapon);
		}

		public Weapon Load (string id)
		{
			Weapon weapon;
			if (weapons.TryGetValue (id, out weapon)) {
				return weapon;
			}
			throw new NotFoundWeaponException (id);
		}

		public void Remove (string id)
		{
			weapons.Remove (id);
		}

		void Start()
		{
			Debug.Log("Application Starting after " + Time.time + " seconds");
			if (File.Exists (Application.persistentDataPath + "/weapons.dat")) {
				BinaryFormatter bf = new BinaryFormatter ();
				FileStream file = File.Open (Application.persistentDataPath + "/weapons.dat", FileMode.Open);
				WeaponStore weaponStore = (WeaponStore)bf.Deserialize (file);
				file.Close ();
				foreach (WeaponData weapon in weaponStore.WeaponList) {
					Save (weapon.Weapon());
				}
			}
		}

		void OnApplicationQuit()
		{
			Debug.Log("Application ending after " + Time.time + " seconds");
			WeaponStore weaponStore = new WeaponStore ();
			foreach (KeyValuePair<string, Weapon> weaponWrapper in weapons) {
				weaponStore.AddWeapon (new WeaponData(weaponWrapper.Value));
			}
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/weapons.dat", FileMode.OpenOrCreate);
			bf.Serialize (file, weaponStore);
			file.Close ();
		}
	}

	[Serializable]
	internal class WeaponData
	{
		public string id;
		public string name;
		public float damage;
		public float coldDown;

		public WeaponData (Weapon weapon)
		{
			id = weapon.Id;
			name = weapon.Name;
			damage = weapon.Damage;
			coldDown = weapon.ColdDown;
		}

		public Weapon Weapon()
		{
			return new Weapon (id, name, damage, coldDown);
		}
	}

	[Serializable]
	internal class WeaponStore
	{
		private ArrayList weaponList;

		public WeaponStore ()
		{
			weaponList = new ArrayList();
		}

		public void AddWeapon(WeaponData weaponData)
		{
			weaponList.Add (weaponData);
		}

		public ArrayList WeaponList {
			get {
				return this.weaponList;
			}
		}
	}
}
