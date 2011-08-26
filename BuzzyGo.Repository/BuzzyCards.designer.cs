﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.235
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BuzzyGo.Repository
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="BuzzyGo")]
	public partial class BuzzyCardsDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertObjectSequence(ObjectSequence instance);
    partial void UpdateObjectSequence(ObjectSequence instance);
    partial void DeleteObjectSequence(ObjectSequence instance);
    partial void InsertBuzzCategory(BuzzCategory instance);
    partial void UpdateBuzzCategory(BuzzCategory instance);
    partial void DeleteBuzzCategory(BuzzCategory instance);
    partial void InsertBuzzword(Buzzword instance);
    partial void UpdateBuzzword(Buzzword instance);
    partial void DeleteBuzzword(Buzzword instance);
    partial void InsertCardSquare(CardSquare instance);
    partial void UpdateCardSquare(CardSquare instance);
    partial void DeleteCardSquare(CardSquare instance);
    partial void InsertCard(Card instance);
    partial void UpdateCard(Card instance);
    partial void DeleteCard(Card instance);
    #endregion
		
		public BuzzyCardsDataContext() : 
				base(global::BuzzyGo.Repository.Properties.Settings.Default.BuzzyGoConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public BuzzyCardsDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public BuzzyCardsDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public BuzzyCardsDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public BuzzyCardsDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<ObjectSequence> ObjectSequences
		{
			get
			{
				return this.GetTable<ObjectSequence>();
			}
		}
		
		public System.Data.Linq.Table<BuzzCategory> BuzzCategories
		{
			get
			{
				return this.GetTable<BuzzCategory>();
			}
		}
		
		public System.Data.Linq.Table<Buzzword> Buzzwords
		{
			get
			{
				return this.GetTable<Buzzword>();
			}
		}
		
		public System.Data.Linq.Table<CardSquare> CardSquares
		{
			get
			{
				return this.GetTable<CardSquare>();
			}
		}
		
		public System.Data.Linq.Table<Card> Cards
		{
			get
			{
				return this.GetTable<Card>();
			}
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.GetNewSeqVal_ObjectSequence")]
		public int GetNewSequence([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="UniqueIdentifier")] System.Nullable<System.Guid> seqGuid, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="BigInt")] ref System.Nullable<long> newSeqVal)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), seqGuid, newSeqVal);
			newSeqVal = ((System.Nullable<long>)(result.GetParameterValue(1)));
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.OBJECTSEQUENCE_GetGuidForSequence")]
		public int GetGuidForSequence([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="BigInt")] System.Nullable<long> sequenceID, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="UniqueIdentifier")] ref System.Nullable<System.Guid> sequenceValue)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), sequenceID, sequenceValue);
			sequenceValue = ((System.Nullable<System.Guid>)(result.GetParameterValue(1)));
			return ((int)(result.ReturnValue));
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ObjectSequence")]
	public partial class ObjectSequence : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _SeqID;
		
		private System.Guid _SeqVal;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnSeqIDChanging(long value);
    partial void OnSeqIDChanged();
    partial void OnSeqValChanging(System.Guid value);
    partial void OnSeqValChanged();
    #endregion
		
		public ObjectSequence()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SeqID", DbType="BigInt NOT NULL", IsPrimaryKey=true)]
		public long SeqID
		{
			get
			{
				return this._SeqID;
			}
			set
			{
				if ((this._SeqID != value))
				{
					this.OnSeqIDChanging(value);
					this.SendPropertyChanging();
					this._SeqID = value;
					this.SendPropertyChanged("SeqID");
					this.OnSeqIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SeqVal", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid SeqVal
		{
			get
			{
				return this._SeqVal;
			}
			set
			{
				if ((this._SeqVal != value))
				{
					this.OnSeqValChanging(value);
					this.SendPropertyChanging();
					this._SeqVal = value;
					this.SendPropertyChanged("SeqVal");
					this.OnSeqValChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.BuzzCategory")]
	public partial class BuzzCategory : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _ID;
		
		private long _CategoryID;
		
		private string _Name;
		
		private System.DateTime _DateCreated;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(System.Guid value);
    partial void OnIDChanged();
    partial void OnCategoryIDChanging(long value);
    partial void OnCategoryIDChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnDateCreatedChanging(System.DateTime value);
    partial void OnDateCreatedChanged();
    #endregion
		
		public BuzzCategory()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CategoryID", DbType="BigInt NOT NULL")]
		public long CategoryID
		{
			get
			{
				return this._CategoryID;
			}
			set
			{
				if ((this._CategoryID != value))
				{
					this.OnCategoryIDChanging(value);
					this.SendPropertyChanging();
					this._CategoryID = value;
					this.SendPropertyChanged("CategoryID");
					this.OnCategoryIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(500) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateCreated", DbType="DateTime NOT NULL")]
		public System.DateTime DateCreated
		{
			get
			{
				return this._DateCreated;
			}
			set
			{
				if ((this._DateCreated != value))
				{
					this.OnDateCreatedChanging(value);
					this.SendPropertyChanging();
					this._DateCreated = value;
					this.SendPropertyChanged("DateCreated");
					this.OnDateCreatedChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Buzzword")]
	public partial class Buzzword : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _ID;
		
		private long _BuzzID;
		
		private string _Name;
		
		private string _Category;
		
		private System.DateTime _DateCreated;
		
		private int _TimesUsed;
		
		private int _TimesMarked;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(System.Guid value);
    partial void OnIDChanged();
    partial void OnBuzzIDChanging(long value);
    partial void OnBuzzIDChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnCategoryChanging(string value);
    partial void OnCategoryChanged();
    partial void OnDateCreatedChanging(System.DateTime value);
    partial void OnDateCreatedChanged();
    partial void OnTimesUsedChanging(int value);
    partial void OnTimesUsedChanged();
    partial void OnTimesMarkedChanging(int value);
    partial void OnTimesMarkedChanged();
    #endregion
		
		public Buzzword()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BuzzID", DbType="BigInt NOT NULL")]
		public long BuzzID
		{
			get
			{
				return this._BuzzID;
			}
			set
			{
				if ((this._BuzzID != value))
				{
					this.OnBuzzIDChanging(value);
					this.SendPropertyChanging();
					this._BuzzID = value;
					this.SendPropertyChanged("BuzzID");
					this.OnBuzzIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(500) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Category", DbType="NVarChar(500) NOT NULL", CanBeNull=false)]
		public string Category
		{
			get
			{
				return this._Category;
			}
			set
			{
				if ((this._Category != value))
				{
					this.OnCategoryChanging(value);
					this.SendPropertyChanging();
					this._Category = value;
					this.SendPropertyChanged("Category");
					this.OnCategoryChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateCreated", DbType="DateTime NOT NULL")]
		public System.DateTime DateCreated
		{
			get
			{
				return this._DateCreated;
			}
			set
			{
				if ((this._DateCreated != value))
				{
					this.OnDateCreatedChanging(value);
					this.SendPropertyChanging();
					this._DateCreated = value;
					this.SendPropertyChanged("DateCreated");
					this.OnDateCreatedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TimesUsed", DbType="Int NOT NULL")]
		public int TimesUsed
		{
			get
			{
				return this._TimesUsed;
			}
			set
			{
				if ((this._TimesUsed != value))
				{
					this.OnTimesUsedChanging(value);
					this.SendPropertyChanging();
					this._TimesUsed = value;
					this.SendPropertyChanged("TimesUsed");
					this.OnTimesUsedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TimesMarked", DbType="Int NOT NULL")]
		public int TimesMarked
		{
			get
			{
				return this._TimesMarked;
			}
			set
			{
				if ((this._TimesMarked != value))
				{
					this.OnTimesMarkedChanging(value);
					this.SendPropertyChanging();
					this._TimesMarked = value;
					this.SendPropertyChanged("TimesMarked");
					this.OnTimesMarkedChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.CardSquare")]
	public partial class CardSquare : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _CardID;
		
		private string _Name;
		
		private int _RowNum;
		
		private int _ColNum;
		
		private string _Value;
		
		private bool _IsMarked;
		
		private System.DateTime _DateCreated;
		
		private System.DateTime _DateUpdated;
		
		private System.Guid _SquareID;
		
		private long _BuzzID;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnCardIDChanging(long value);
    partial void OnCardIDChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnRowNumChanging(int value);
    partial void OnRowNumChanged();
    partial void OnColNumChanging(int value);
    partial void OnColNumChanged();
    partial void OnValueChanging(string value);
    partial void OnValueChanged();
    partial void OnIsMarkedChanging(bool value);
    partial void OnIsMarkedChanged();
    partial void OnDateCreatedChanging(System.DateTime value);
    partial void OnDateCreatedChanged();
    partial void OnDateUpdatedChanging(System.DateTime value);
    partial void OnDateUpdatedChanged();
    partial void OnSquareIDChanging(System.Guid value);
    partial void OnSquareIDChanged();
    partial void OnBuzzIDChanging(long value);
    partial void OnBuzzIDChanged();
    #endregion
		
		public CardSquare()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CardID", DbType="BigInt NOT NULL")]
		public long CardID
		{
			get
			{
				return this._CardID;
			}
			set
			{
				if ((this._CardID != value))
				{
					this.OnCardIDChanging(value);
					this.SendPropertyChanging();
					this._CardID = value;
					this.SendPropertyChanged("CardID");
					this.OnCardIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(500) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RowNum", DbType="Int NOT NULL")]
		public int RowNum
		{
			get
			{
				return this._RowNum;
			}
			set
			{
				if ((this._RowNum != value))
				{
					this.OnRowNumChanging(value);
					this.SendPropertyChanging();
					this._RowNum = value;
					this.SendPropertyChanged("RowNum");
					this.OnRowNumChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ColNum", DbType="Int NOT NULL")]
		public int ColNum
		{
			get
			{
				return this._ColNum;
			}
			set
			{
				if ((this._ColNum != value))
				{
					this.OnColNumChanging(value);
					this.SendPropertyChanging();
					this._ColNum = value;
					this.SendPropertyChanged("ColNum");
					this.OnColNumChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Value", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Value
		{
			get
			{
				return this._Value;
			}
			set
			{
				if ((this._Value != value))
				{
					this.OnValueChanging(value);
					this.SendPropertyChanging();
					this._Value = value;
					this.SendPropertyChanged("Value");
					this.OnValueChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsMarked", DbType="Bit NOT NULL")]
		public bool IsMarked
		{
			get
			{
				return this._IsMarked;
			}
			set
			{
				if ((this._IsMarked != value))
				{
					this.OnIsMarkedChanging(value);
					this.SendPropertyChanging();
					this._IsMarked = value;
					this.SendPropertyChanged("IsMarked");
					this.OnIsMarkedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateCreated", DbType="DateTime NOT NULL")]
		public System.DateTime DateCreated
		{
			get
			{
				return this._DateCreated;
			}
			set
			{
				if ((this._DateCreated != value))
				{
					this.OnDateCreatedChanging(value);
					this.SendPropertyChanging();
					this._DateCreated = value;
					this.SendPropertyChanged("DateCreated");
					this.OnDateCreatedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateUpdated", DbType="DateTime NOT NULL")]
		public System.DateTime DateUpdated
		{
			get
			{
				return this._DateUpdated;
			}
			set
			{
				if ((this._DateUpdated != value))
				{
					this.OnDateUpdatedChanging(value);
					this.SendPropertyChanging();
					this._DateUpdated = value;
					this.SendPropertyChanged("DateUpdated");
					this.OnDateUpdatedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SquareID", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid SquareID
		{
			get
			{
				return this._SquareID;
			}
			set
			{
				if ((this._SquareID != value))
				{
					this.OnSquareIDChanging(value);
					this.SendPropertyChanging();
					this._SquareID = value;
					this.SendPropertyChanged("SquareID");
					this.OnSquareIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BuzzID", DbType="BigInt NOT NULL")]
		public long BuzzID
		{
			get
			{
				return this._BuzzID;
			}
			set
			{
				if ((this._BuzzID != value))
				{
					this.OnBuzzIDChanging(value);
					this.SendPropertyChanging();
					this._BuzzID = value;
					this.SendPropertyChanged("BuzzID");
					this.OnBuzzIDChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Card")]
	public partial class Card : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _ID;
		
		private long _CardID;
		
		private string _Name;
		
		private string _Purpose;
		
		private System.DateTime _DateCreated;
		
		private bool _IsActive;
		
		private bool _IsWinner;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(System.Guid value);
    partial void OnIDChanged();
    partial void OnCardIDChanging(long value);
    partial void OnCardIDChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnPurposeChanging(string value);
    partial void OnPurposeChanged();
    partial void OnDateCreatedChanging(System.DateTime value);
    partial void OnDateCreatedChanged();
    partial void OnIsActiveChanging(bool value);
    partial void OnIsActiveChanged();
    partial void OnIsWinnerChanging(bool value);
    partial void OnIsWinnerChanged();
    #endregion
		
		public Card()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CardID", DbType="BigInt NOT NULL")]
		public long CardID
		{
			get
			{
				return this._CardID;
			}
			set
			{
				if ((this._CardID != value))
				{
					this.OnCardIDChanging(value);
					this.SendPropertyChanging();
					this._CardID = value;
					this.SendPropertyChanged("CardID");
					this.OnCardIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(500) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Purpose", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Purpose
		{
			get
			{
				return this._Purpose;
			}
			set
			{
				if ((this._Purpose != value))
				{
					this.OnPurposeChanging(value);
					this.SendPropertyChanging();
					this._Purpose = value;
					this.SendPropertyChanged("Purpose");
					this.OnPurposeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateCreated", DbType="DateTime NOT NULL")]
		public System.DateTime DateCreated
		{
			get
			{
				return this._DateCreated;
			}
			set
			{
				if ((this._DateCreated != value))
				{
					this.OnDateCreatedChanging(value);
					this.SendPropertyChanging();
					this._DateCreated = value;
					this.SendPropertyChanged("DateCreated");
					this.OnDateCreatedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsActive", DbType="Bit NOT NULL")]
		public bool IsActive
		{
			get
			{
				return this._IsActive;
			}
			set
			{
				if ((this._IsActive != value))
				{
					this.OnIsActiveChanging(value);
					this.SendPropertyChanging();
					this._IsActive = value;
					this.SendPropertyChanged("IsActive");
					this.OnIsActiveChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsWinner", DbType="Bit NOT NULL")]
		public bool IsWinner
		{
			get
			{
				return this._IsWinner;
			}
			set
			{
				if ((this._IsWinner != value))
				{
					this.OnIsWinnerChanging(value);
					this.SendPropertyChanging();
					this._IsWinner = value;
					this.SendPropertyChanged("IsWinner");
					this.OnIsWinnerChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591