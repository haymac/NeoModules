﻿using Newtonsoft.Json;

namespace NeoModules.NEP6.Models
{
	public class Account
	{
		/// <summary>
		/// The base58 encoded address of the account 
		/// e.g. AQLASLtT6pWbThcSCYU1biVqhMnzhTgLFq
		/// </summary>
		[JsonProperty("address")]
		public string Address { get; }

		/// <summary>
		/// Label that the user has made to the account. 
		/// </summary>
		[JsonProperty("label")]
		public string Label { get; set; }

		/// <summary>
		/// Indicates whether the account is the default change account.
		/// </summary>
		[JsonProperty("isDefault")]
		public bool IsDefault { get; set; }

		/// <summary>
		/// Indicates whether the account is locked by user. The client shouldn't spend the funds in a locked account. 
		/// </summary>
		[JsonProperty("lock")]
		public bool IsLock { get; set; }

		/// <summary>
		/// The private key of the account in the NEP-2 format. This field can be null (for watch-only address or non-standard address). 
		/// e.g. 6PYWB8m1bCnu5bQkRUKAwbZp2BHNvQ3BQRLbpLdTuizpyLkQPSZbtZfoxx
		/// </summary>
		[JsonProperty("key")]
		public string Key { get; private set; }

		/// <summary>
		/// Contract object which describes the details of the contract.
		/// </summary>
		[JsonProperty("contract")]
		public Contract Contract { get; set; }

		/// <summary>
		/// An object that is defined by the implementor of the client for storing extra data. This field can be null
		/// </summary>
		[JsonProperty("extra")]
		public object Extra { get; set; }

		[JsonConstructor]
		public Account(string address, string label, bool isDefault, bool isLock, string key = null, Contract contract = null, object extra = null)
		{
			Address = address;
			Label = label;
			IsDefault = isDefault;
			IsLock = isLock;
			Key = key;
			Contract = contract;
			Extra = extra;
		}

		public static Account FromJson(string json) => JsonConvert.DeserializeObject<Account>(json);

		public static string ToJson(Account self) => JsonConvert.SerializeObject(self);
	}
}