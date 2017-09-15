//---------------------------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated by T4Model template for T4 (https://github.com/linq2db/t4models).
//    Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//---------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

using LinqToDB;
using LinqToDB.DataProvider.SqlServer;
using LinqToDB.Extensions;
using LinqToDB.Mapping;

namespace DataModels
{
	/// <summary>
	/// Database       : stajdatabase
	/// Data Source    : stajdatabase.mssql.somee.com
	/// Server Version : 13.00.1601
	/// </summary>
	public partial class StajdatabaseDB : LinqToDB.Data.DataConnection
	{
		public ITable<Brand>               Brands                { get { return this.GetTable<Brand>(); } }
		public ITable<Model>               Models                { get { return this.GetTable<Model>(); } }
		public ITable<RUsersModelsQuality> RUsersModelsQualities { get { return this.GetTable<RUsersModelsQuality>(); } }
		public ITable<User>                Users                 { get { return this.GetTable<User>(); } }

		public StajdatabaseDB()
		{
			InitDataContext();
		}

		public StajdatabaseDB(string configuration)
			: base(configuration)
		{
			InitDataContext();
		}

		partial void InitDataContext();

		#region FreeTextTable

		public class FreeTextKey<T>
		{
			public T   Key;
			public int Rank;
		}

		private static MethodInfo _freeTextTableMethod1 = typeof(StajdatabaseDB).GetMethod("FreeTextTable", new Type[] { typeof(string), typeof(string) });

		[FreeTextTableExpression]
		public ITable<FreeTextKey<TKey>> FreeTextTable<TTable,TKey>(string field, string text)
		{
			return this.GetTable<FreeTextKey<TKey>>(
				this,
				_freeTextTableMethod1,
				field,
				text);
		}

		private static MethodInfo _freeTextTableMethod2 = 
			typeof(StajdatabaseDB).GetMethods()
				.Where(m => m.Name == "FreeTextTable" &&  m.IsGenericMethod && m.GetParameters().Length == 2)
				.Where(m => m.GetParameters()[0].ParameterType.IsGenericTypeEx() && m.GetParameters()[0].ParameterType.GetGenericTypeDefinition() == typeof(Expression<>))
				.Where(m => m.GetParameters()[1].ParameterType == typeof(string))
				.Single();

		[FreeTextTableExpression]
		public ITable<FreeTextKey<TKey>> FreeTextTable<TTable,TKey>(Expression<Func<TTable,string>> fieldSelector, string text)
		{
			return this.GetTable<FreeTextKey<TKey>>(
				this,
				_freeTextTableMethod2,
				fieldSelector,
				text);
		}

		#endregion
	}

	[Table(Schema="dbo", Name="Brands")]
	public partial class Brand
	{
		[Column("id"), PrimaryKey, Identity] public int    �d        { get; set; } // int
		[Column(),     NotNull             ] public string BrandName { get; set; } // nvarchar(50)

		#region Associations

		/// <summary>
		/// FK_Models_Brands_BackReference
		/// </summary>
		[Association(ThisKey="�d", OtherKey="BrandId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<Model> Models { get; set; }

		#endregion
	}

	[Table(Schema="dbo", Name="Models")]
	public partial class Model
	{
		[Column("id"), PrimaryKey, Identity] public int    �d        { get; set; } // int
		[Column(),     NotNull             ] public int    BrandId   { get; set; } // int
		[Column(),     NotNull             ] public string ModelName { get; set; } // nvarchar(50)

		#region Associations

		/// <summary>
		/// FK_Models_Brands
		/// </summary>
		[Association(ThisKey="BrandId", OtherKey="�d", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="FK_Models_Brands", BackReferenceName="Models")]
		public Brand Brand { get; set; }

		/// <summary>
		/// FK_Qualities_Models_BackReference
		/// </summary>
		[Association(ThisKey="�d", OtherKey="ModelId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<RUsersModelsQuality> Qualities { get; set; }

		#endregion
	}

	[Table(Schema="dbo", Name="RUsersModelsQualities")]
	public partial class RUsersModelsQuality
	{
		[Column("id"), PrimaryKey,  Identity] public int      �d       { get; set; } // int
		[Column(),        Nullable          ] public decimal? Price    { get; set; } // decimal(18, 2)
		[Column(),        Nullable          ] public int?     Km       { get; set; } // int
		[Column(),        Nullable          ] public string   SubModel { get; set; } // nvarchar(50)
		[Column(),        Nullable          ] public int?     Year     { get; set; } // int
		[Column(),     NotNull              ] public int      ModelId  { get; set; } // int
		[Column(),     NotNull              ] public int      UserId   { get; set; } // int
		[Column(),        Nullable          ] public string   Color    { get; set; } // nvarchar(50)

		#region Associations

		/// <summary>
		/// FK_Qualities_Models
		/// </summary>
		[Association(ThisKey="ModelId", OtherKey="�d", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="FK_Qualities_Models", BackReferenceName="Qualities")]
		public Model QualitiesModel { get; set; }

		/// <summary>
		/// FK_RUsersModelsQualities_Users
		/// </summary>
		[Association(ThisKey="UserId", OtherKey="�d", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="FK_RUsersModelsQualities_Users", BackReferenceName="RUsersModelsQualities")]
		public User User { get; set; }

		#endregion
	}

	[Table(Schema="dbo", Name="Users")]
	public partial class User
	{
		[Column("id"), PrimaryKey, NotNull] public int    �d       { get; set; } // int
		[Column(),                 NotNull] public string UserName { get; set; } // nvarchar(50)
		[Column(),                 NotNull] public string UserMail { get; set; } // nvarchar(50)

		#region Associations

		/// <summary>
		/// FK_RUsersModelsQualities_Users_BackReference
		/// </summary>
		[Association(ThisKey="�d", OtherKey="UserId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<RUsersModelsQuality> RUsersModelsQualities { get; set; }

		#endregion
	}

	public static partial class TableExtensions
	{
		public static Brand Find(this ITable<Brand> table, int �d)
		{
			return table.FirstOrDefault(t =>
				t.�d == �d);
		}

		public static Model Find(this ITable<Model> table, int �d)
		{
			return table.FirstOrDefault(t =>
				t.�d == �d);
		}

		public static RUsersModelsQuality Find(this ITable<RUsersModelsQuality> table, int �d)
		{
			return table.FirstOrDefault(t =>
				t.�d == �d);
		}

		public static User Find(this ITable<User> table, int �d)
		{
			return table.FirstOrDefault(t =>
				t.�d == �d);
		}
	}
}