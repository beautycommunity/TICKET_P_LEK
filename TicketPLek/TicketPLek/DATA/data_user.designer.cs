﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TicketPLek.DATA
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="BeautyTicket-Live")]
	public partial class data_userDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertMAS_USER(MAS_USER instance);
    partial void UpdateMAS_USER(MAS_USER instance);
    partial void DeleteMAS_USER(MAS_USER instance);
    partial void InsertMAS_DEP(MAS_DEP instance);
    partial void UpdateMAS_DEP(MAS_DEP instance);
    partial void DeleteMAS_DEP(MAS_DEP instance);
    #endregion
		
		public data_userDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["BeautyTicket_LiveConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public data_userDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public data_userDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public data_userDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public data_userDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<MAS_USER_A> MAS_USER_As
		{
			get
			{
				return this.GetTable<MAS_USER_A>();
			}
		}
		
		public System.Data.Linq.Table<MAS_USER> MAS_USERs
		{
			get
			{
				return this.GetTable<MAS_USER>();
			}
		}
		
		public System.Data.Linq.Table<MAS_DEP> MAS_DEPs
		{
			get
			{
				return this.GetTable<MAS_DEP>();
			}
		}
		
		public System.Data.Linq.Table<VW_USER_ALL> VW_USER_ALLs
		{
			get
			{
				return this.GetTable<VW_USER_ALL>();
			}
		}
		
		public System.Data.Linq.Table<VW_USER_FOR_LE> VW_USER_FOR_LEs
		{
			get
			{
				return this.GetTable<VW_USER_FOR_LE>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.MAS_USER_A")]
	public partial class MAS_USER_A
	{
		
		private int _US_ID;
		
		private string _ANAME;
		
		private string _CFLAG;
		
		private string _createcode;
		
		private System.Nullable<System.DateTime> _createdate;
		
		public MAS_USER_A()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_US_ID", AutoSync=AutoSync.Always, DbType="Int NOT NULL IDENTITY", IsDbGenerated=true)]
		public int US_ID
		{
			get
			{
				return this._US_ID;
			}
			set
			{
				if ((this._US_ID != value))
				{
					this._US_ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ANAME", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string ANAME
		{
			get
			{
				return this._ANAME;
			}
			set
			{
				if ((this._ANAME != value))
				{
					this._ANAME = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CFLAG", DbType="NChar(10) NOT NULL", CanBeNull=false)]
		public string CFLAG
		{
			get
			{
				return this._CFLAG;
			}
			set
			{
				if ((this._CFLAG != value))
				{
					this._CFLAG = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_createcode", DbType="NVarChar(20)")]
		public string createcode
		{
			get
			{
				return this._createcode;
			}
			set
			{
				if ((this._createcode != value))
				{
					this._createcode = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_createdate", DbType="DateTime")]
		public System.Nullable<System.DateTime> createdate
		{
			get
			{
				return this._createdate;
			}
			set
			{
				if ((this._createdate != value))
				{
					this._createdate = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.MAS_USER")]
	public partial class MAS_USER : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _US_ID;
		
		private string _STCODE;
		
		private string _PASSWORD;
		
		private string _FNAME;
		
		private string _LNAME;
		
		private string _NICKNAME;
		
		private string _MAIL;
		
		private System.Nullable<char> _SEX;
		
		private int _D_ID;
		
		private byte _A_ID;
		
		private byte _CFLAG;
		
		private string _CREATECODE;
		
		private System.Nullable<System.DateTime> _CREATEDATE;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUS_IDChanging(int value);
    partial void OnUS_IDChanged();
    partial void OnSTCODEChanging(string value);
    partial void OnSTCODEChanged();
    partial void OnPASSWORDChanging(string value);
    partial void OnPASSWORDChanged();
    partial void OnFNAMEChanging(string value);
    partial void OnFNAMEChanged();
    partial void OnLNAMEChanging(string value);
    partial void OnLNAMEChanged();
    partial void OnNICKNAMEChanging(string value);
    partial void OnNICKNAMEChanged();
    partial void OnMAILChanging(string value);
    partial void OnMAILChanged();
    partial void OnSEXChanging(System.Nullable<char> value);
    partial void OnSEXChanged();
    partial void OnD_IDChanging(int value);
    partial void OnD_IDChanged();
    partial void OnA_IDChanging(byte value);
    partial void OnA_IDChanged();
    partial void OnCFLAGChanging(byte value);
    partial void OnCFLAGChanged();
    partial void OnCREATECODEChanging(string value);
    partial void OnCREATECODEChanged();
    partial void OnCREATEDATEChanging(System.Nullable<System.DateTime> value);
    partial void OnCREATEDATEChanged();
    #endregion
		
		public MAS_USER()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_US_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int US_ID
		{
			get
			{
				return this._US_ID;
			}
			set
			{
				if ((this._US_ID != value))
				{
					this.OnUS_IDChanging(value);
					this.SendPropertyChanging();
					this._US_ID = value;
					this.SendPropertyChanged("US_ID");
					this.OnUS_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_STCODE", DbType="VarChar(50)")]
		public string STCODE
		{
			get
			{
				return this._STCODE;
			}
			set
			{
				if ((this._STCODE != value))
				{
					this.OnSTCODEChanging(value);
					this.SendPropertyChanging();
					this._STCODE = value;
					this.SendPropertyChanged("STCODE");
					this.OnSTCODEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PASSWORD", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string PASSWORD
		{
			get
			{
				return this._PASSWORD;
			}
			set
			{
				if ((this._PASSWORD != value))
				{
					this.OnPASSWORDChanging(value);
					this.SendPropertyChanging();
					this._PASSWORD = value;
					this.SendPropertyChanged("PASSWORD");
					this.OnPASSWORDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FNAME", DbType="VarChar(50)")]
		public string FNAME
		{
			get
			{
				return this._FNAME;
			}
			set
			{
				if ((this._FNAME != value))
				{
					this.OnFNAMEChanging(value);
					this.SendPropertyChanging();
					this._FNAME = value;
					this.SendPropertyChanged("FNAME");
					this.OnFNAMEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LNAME", DbType="VarChar(50)")]
		public string LNAME
		{
			get
			{
				return this._LNAME;
			}
			set
			{
				if ((this._LNAME != value))
				{
					this.OnLNAMEChanging(value);
					this.SendPropertyChanging();
					this._LNAME = value;
					this.SendPropertyChanged("LNAME");
					this.OnLNAMEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NICKNAME", DbType="VarChar(50)")]
		public string NICKNAME
		{
			get
			{
				return this._NICKNAME;
			}
			set
			{
				if ((this._NICKNAME != value))
				{
					this.OnNICKNAMEChanging(value);
					this.SendPropertyChanging();
					this._NICKNAME = value;
					this.SendPropertyChanged("NICKNAME");
					this.OnNICKNAMEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MAIL", DbType="VarChar(255)")]
		public string MAIL
		{
			get
			{
				return this._MAIL;
			}
			set
			{
				if ((this._MAIL != value))
				{
					this.OnMAILChanging(value);
					this.SendPropertyChanging();
					this._MAIL = value;
					this.SendPropertyChanged("MAIL");
					this.OnMAILChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SEX", DbType="Char(1)")]
		public System.Nullable<char> SEX
		{
			get
			{
				return this._SEX;
			}
			set
			{
				if ((this._SEX != value))
				{
					this.OnSEXChanging(value);
					this.SendPropertyChanging();
					this._SEX = value;
					this.SendPropertyChanged("SEX");
					this.OnSEXChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_D_ID", DbType="Int NOT NULL")]
		public int D_ID
		{
			get
			{
				return this._D_ID;
			}
			set
			{
				if ((this._D_ID != value))
				{
					this.OnD_IDChanging(value);
					this.SendPropertyChanging();
					this._D_ID = value;
					this.SendPropertyChanged("D_ID");
					this.OnD_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_A_ID", DbType="TinyInt NOT NULL")]
		public byte A_ID
		{
			get
			{
				return this._A_ID;
			}
			set
			{
				if ((this._A_ID != value))
				{
					this.OnA_IDChanging(value);
					this.SendPropertyChanging();
					this._A_ID = value;
					this.SendPropertyChanged("A_ID");
					this.OnA_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CFLAG", DbType="TinyInt NOT NULL")]
		public byte CFLAG
		{
			get
			{
				return this._CFLAG;
			}
			set
			{
				if ((this._CFLAG != value))
				{
					this.OnCFLAGChanging(value);
					this.SendPropertyChanging();
					this._CFLAG = value;
					this.SendPropertyChanged("CFLAG");
					this.OnCFLAGChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CREATECODE", DbType="VarChar(50)")]
		public string CREATECODE
		{
			get
			{
				return this._CREATECODE;
			}
			set
			{
				if ((this._CREATECODE != value))
				{
					this.OnCREATECODEChanging(value);
					this.SendPropertyChanging();
					this._CREATECODE = value;
					this.SendPropertyChanged("CREATECODE");
					this.OnCREATECODEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CREATEDATE", DbType="DateTime")]
		public System.Nullable<System.DateTime> CREATEDATE
		{
			get
			{
				return this._CREATEDATE;
			}
			set
			{
				if ((this._CREATEDATE != value))
				{
					this.OnCREATEDATEChanging(value);
					this.SendPropertyChanging();
					this._CREATEDATE = value;
					this.SendPropertyChanged("CREATEDATE");
					this.OnCREATEDATEChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.MAS_DEP")]
	public partial class MAS_DEP : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _DP_ID;
		
		private string _DPCODE;
		
		private string _DEPARTMENT;
		
		private System.Nullable<char> _CFLAG;
		
		private string _CREATECODE;
		
		private System.Nullable<System.DateTime> _CREATEDATE;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnDP_IDChanging(int value);
    partial void OnDP_IDChanged();
    partial void OnDPCODEChanging(string value);
    partial void OnDPCODEChanged();
    partial void OnDEPARTMENTChanging(string value);
    partial void OnDEPARTMENTChanged();
    partial void OnCFLAGChanging(System.Nullable<char> value);
    partial void OnCFLAGChanged();
    partial void OnCREATECODEChanging(string value);
    partial void OnCREATECODEChanged();
    partial void OnCREATEDATEChanging(System.Nullable<System.DateTime> value);
    partial void OnCREATEDATEChanged();
    #endregion
		
		public MAS_DEP()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DP_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int DP_ID
		{
			get
			{
				return this._DP_ID;
			}
			set
			{
				if ((this._DP_ID != value))
				{
					this.OnDP_IDChanging(value);
					this.SendPropertyChanging();
					this._DP_ID = value;
					this.SendPropertyChanged("DP_ID");
					this.OnDP_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DPCODE", DbType="NVarChar(10) NOT NULL", CanBeNull=false)]
		public string DPCODE
		{
			get
			{
				return this._DPCODE;
			}
			set
			{
				if ((this._DPCODE != value))
				{
					this.OnDPCODEChanging(value);
					this.SendPropertyChanging();
					this._DPCODE = value;
					this.SendPropertyChanged("DPCODE");
					this.OnDPCODEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DEPARTMENT", DbType="NVarChar(255)")]
		public string DEPARTMENT
		{
			get
			{
				return this._DEPARTMENT;
			}
			set
			{
				if ((this._DEPARTMENT != value))
				{
					this.OnDEPARTMENTChanging(value);
					this.SendPropertyChanging();
					this._DEPARTMENT = value;
					this.SendPropertyChanged("DEPARTMENT");
					this.OnDEPARTMENTChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CFLAG", DbType="NChar(1)")]
		public System.Nullable<char> CFLAG
		{
			get
			{
				return this._CFLAG;
			}
			set
			{
				if ((this._CFLAG != value))
				{
					this.OnCFLAGChanging(value);
					this.SendPropertyChanging();
					this._CFLAG = value;
					this.SendPropertyChanged("CFLAG");
					this.OnCFLAGChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CREATECODE", DbType="NVarChar(20)")]
		public string CREATECODE
		{
			get
			{
				return this._CREATECODE;
			}
			set
			{
				if ((this._CREATECODE != value))
				{
					this.OnCREATECODEChanging(value);
					this.SendPropertyChanging();
					this._CREATECODE = value;
					this.SendPropertyChanged("CREATECODE");
					this.OnCREATECODEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CREATEDATE", DbType="DateTime")]
		public System.Nullable<System.DateTime> CREATEDATE
		{
			get
			{
				return this._CREATEDATE;
			}
			set
			{
				if ((this._CREATEDATE != value))
				{
					this.OnCREATEDATEChanging(value);
					this.SendPropertyChanging();
					this._CREATEDATE = value;
					this.SendPropertyChanged("CREATEDATE");
					this.OnCREATEDATEChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.VW_USER_ALL")]
	public partial class VW_USER_ALL
	{
		
		private int _US_ID;
		
		private string _STCODE;
		
		private string _PASSWORD;
		
		private string _FNAME;
		
		private string _LNAME;
		
		private string _NICKNAME;
		
		private string _MAIL;
		
		private System.Nullable<char> _SEX;
		
		private int _D_ID;
		
		private byte _A_ID;
		
		private byte _CFLAG;
		
		private string _CREATECODE;
		
		private System.Nullable<System.DateTime> _CREATEDATE;
		
		private System.Nullable<int> _DP_ID;
		
		private string _DPCODE;
		
		private string _DEPARTMENT;
		
		private System.Nullable<char> _Expr1;
		
		public VW_USER_ALL()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_US_ID", DbType="Int NOT NULL")]
		public int US_ID
		{
			get
			{
				return this._US_ID;
			}
			set
			{
				if ((this._US_ID != value))
				{
					this._US_ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_STCODE", DbType="VarChar(50)")]
		public string STCODE
		{
			get
			{
				return this._STCODE;
			}
			set
			{
				if ((this._STCODE != value))
				{
					this._STCODE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PASSWORD", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string PASSWORD
		{
			get
			{
				return this._PASSWORD;
			}
			set
			{
				if ((this._PASSWORD != value))
				{
					this._PASSWORD = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FNAME", DbType="VarChar(50)")]
		public string FNAME
		{
			get
			{
				return this._FNAME;
			}
			set
			{
				if ((this._FNAME != value))
				{
					this._FNAME = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LNAME", DbType="VarChar(50)")]
		public string LNAME
		{
			get
			{
				return this._LNAME;
			}
			set
			{
				if ((this._LNAME != value))
				{
					this._LNAME = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NICKNAME", DbType="VarChar(50)")]
		public string NICKNAME
		{
			get
			{
				return this._NICKNAME;
			}
			set
			{
				if ((this._NICKNAME != value))
				{
					this._NICKNAME = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MAIL", DbType="VarChar(255)")]
		public string MAIL
		{
			get
			{
				return this._MAIL;
			}
			set
			{
				if ((this._MAIL != value))
				{
					this._MAIL = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SEX", DbType="Char(1)")]
		public System.Nullable<char> SEX
		{
			get
			{
				return this._SEX;
			}
			set
			{
				if ((this._SEX != value))
				{
					this._SEX = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_D_ID", DbType="Int NOT NULL")]
		public int D_ID
		{
			get
			{
				return this._D_ID;
			}
			set
			{
				if ((this._D_ID != value))
				{
					this._D_ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_A_ID", DbType="TinyInt NOT NULL")]
		public byte A_ID
		{
			get
			{
				return this._A_ID;
			}
			set
			{
				if ((this._A_ID != value))
				{
					this._A_ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CFLAG", DbType="TinyInt NOT NULL")]
		public byte CFLAG
		{
			get
			{
				return this._CFLAG;
			}
			set
			{
				if ((this._CFLAG != value))
				{
					this._CFLAG = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CREATECODE", DbType="VarChar(50)")]
		public string CREATECODE
		{
			get
			{
				return this._CREATECODE;
			}
			set
			{
				if ((this._CREATECODE != value))
				{
					this._CREATECODE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CREATEDATE", DbType="DateTime")]
		public System.Nullable<System.DateTime> CREATEDATE
		{
			get
			{
				return this._CREATEDATE;
			}
			set
			{
				if ((this._CREATEDATE != value))
				{
					this._CREATEDATE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DP_ID", DbType="Int")]
		public System.Nullable<int> DP_ID
		{
			get
			{
				return this._DP_ID;
			}
			set
			{
				if ((this._DP_ID != value))
				{
					this._DP_ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DPCODE", DbType="NVarChar(10)")]
		public string DPCODE
		{
			get
			{
				return this._DPCODE;
			}
			set
			{
				if ((this._DPCODE != value))
				{
					this._DPCODE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DEPARTMENT", DbType="NVarChar(255)")]
		public string DEPARTMENT
		{
			get
			{
				return this._DEPARTMENT;
			}
			set
			{
				if ((this._DEPARTMENT != value))
				{
					this._DEPARTMENT = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Expr1", DbType="NChar(1)")]
		public System.Nullable<char> Expr1
		{
			get
			{
				return this._Expr1;
			}
			set
			{
				if ((this._Expr1 != value))
				{
					this._Expr1 = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.[VW_USER_FOR-LE]")]
	public partial class VW_USER_FOR_LE
	{
		
		private int _US_ID;
		
		private string _STCODE;
		
		private string _NAME;
		
		private string _NICKNAME;
		
		private string _MAIL;
		
		private string _DPCODE;
		
		private byte _A_ID;
		
		private string _ANAME;
		
		public VW_USER_FOR_LE()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_US_ID", DbType="Int NOT NULL")]
		public int US_ID
		{
			get
			{
				return this._US_ID;
			}
			set
			{
				if ((this._US_ID != value))
				{
					this._US_ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_STCODE", DbType="VarChar(50)")]
		public string STCODE
		{
			get
			{
				return this._STCODE;
			}
			set
			{
				if ((this._STCODE != value))
				{
					this._STCODE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NAME", DbType="VarChar(101)")]
		public string NAME
		{
			get
			{
				return this._NAME;
			}
			set
			{
				if ((this._NAME != value))
				{
					this._NAME = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NICKNAME", DbType="VarChar(50)")]
		public string NICKNAME
		{
			get
			{
				return this._NICKNAME;
			}
			set
			{
				if ((this._NICKNAME != value))
				{
					this._NICKNAME = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MAIL", DbType="VarChar(255)")]
		public string MAIL
		{
			get
			{
				return this._MAIL;
			}
			set
			{
				if ((this._MAIL != value))
				{
					this._MAIL = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DPCODE", DbType="NVarChar(10)")]
		public string DPCODE
		{
			get
			{
				return this._DPCODE;
			}
			set
			{
				if ((this._DPCODE != value))
				{
					this._DPCODE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_A_ID", DbType="TinyInt NOT NULL")]
		public byte A_ID
		{
			get
			{
				return this._A_ID;
			}
			set
			{
				if ((this._A_ID != value))
				{
					this._A_ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ANAME", DbType="NVarChar(50)")]
		public string ANAME
		{
			get
			{
				return this._ANAME;
			}
			set
			{
				if ((this._ANAME != value))
				{
					this._ANAME = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
