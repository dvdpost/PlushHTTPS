// 
//  ____  _     __  __      _        _ 
// |  _ \| |__ |  \/  | ___| |_ __ _| |
// | | | | '_ \| |\/| |/ _ \ __/ _` | |
// | |_| | |_) | |  | |  __/ || (_| | |
// |____/|_.__/|_|  |_|\___|\__\__,_|_|
//
// Auto-generated from plush_mobile on 2012-02-03 23:08:07Z.
// Please visit http://code.google.com/p/dblinq2007/ for more information.
//
namespace PlushService
{
	using System;
	using System.ComponentModel;
	using System.Data;
#if MONO_STRICT
	using System.Data.Linq;
#else   // MONO_STRICT
	using DbLinq.Data.Linq;
	using DbLinq.Vendor;
#endif  // MONO_STRICT
	using System.Data.Linq.Mapping;
	using System.Diagnostics;
	
	
	public partial class DVdPostMobileApIWS : DataContext
	{
		
		#region Extensibility Method Declarations
		partial void OnCreated();
		#endregion
		
		
		public DVdPostMobileApIWS(string connectionString) : 
				base(connectionString)
		{
			this.OnCreated();
		}
		
		public DVdPostMobileApIWS(string connection, MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			this.OnCreated();
		}
		
		public DVdPostMobileApIWS(IDbConnection connection, MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			this.OnCreated();
		}
		
		public Table<BestRatedMovies> BestRatedMovies
		{
			get
			{
				return this.GetTable<BestRatedMovies>();
			}
		}
		
		public Table<BestReviewers> BestReviewers
		{
			get
			{
				return this.GetTable<BestReviewers>();
			}
		}
		
		public Table<BestReviews> BestReviews
		{
			get
			{
				return this.GetTable<BestReviews>();
			}
		}
		
		public Table<CatalogCommunity> CatalogCommunity
		{
			get
			{
				return this.GetTable<CatalogCommunity>();
			}
		}
		
		public Table<Categories> Categories
		{
			get
			{
				return this.GetTable<Categories>();
			}
		}
		
		public Table<CreditHistory> CreditHistory
		{
			get
			{
				return this.GetTable<CreditHistory>();
			}
		}
		
		public Table<HpCategories> HpCategories
		{
			get
			{
				return this.GetTable<HpCategories>();
			}
		}
		
		public Table<HpMovie> HpMovie
		{
			get
			{
				return this.GetTable<HpMovie>();
			}
		}
		
		public Table<HpTopTheme> HpTopTheme
		{
			get
			{
				return this.GetTable<HpTopTheme>();
			}
		}

        public Table<HpMenu> HpMenu
        {
            get
            {
                return this.GetTable<HpMenu>();
            }
        }

        public Table<CtLGCentralMenu> CtLGCentralMenu
        {
            get
            {
                return this.GetTable<CtLGCentralMenu>();
            }
        }

        public Table<CtLGLeftMenu> CtLGLeftMenu
        {
            get
            {
                return this.GetTable<CtLGLeftMenu>();
            }
        }
		
		public Table<MostDiscusEdMovies> MostDiscusEdMovies
		{
			get
			{
				return this.GetTable<MostDiscusEdMovies>();
			}
		}
		
		public Table<MostRentedMovies> MostRentedMovies
		{
			get
			{
				return this.GetTable<MostRentedMovies>();
			}
		}
		
		public Table<MovieDVdProducts> MovieDVdProducts
		{
			get
			{
				return this.GetTable<MovieDVdProducts>();
			}
		}
		
		public Table<MoviesRates> MoviesRates
		{
			get
			{
				return this.GetTable<MoviesRates>();
			}
		}
		
		public Table<ProductsLastModifiedOrdered> ProductsLastModifiedOrdered
		{
			get
			{
				return this.GetTable<ProductsLastModifiedOrdered>();
			}
		}
		
		public Table<TopMovies> TopMovies
		{
			get
			{
				return this.GetTable<TopMovies>();
			}
		}
	}
	
	#region Start MONO_STRICT
#if MONO_STRICT

	public partial class DVdPostMobileApIWS
	{
		
		public DVdPostMobileApIWS(IDbConnection connection) : 
				base(connection)
		{
			this.OnCreated();
		}
	}
	#region End MONO_STRICT
	#endregion
#else     // MONO_STRICT
	
	public partial class DVdPostMobileApIWS
	{
		
		public DVdPostMobileApIWS(IDbConnection connection) : 
				base(connection, new DbLinq.MySql.MySqlVendor())
		{
			this.OnCreated();
		}
		
		public DVdPostMobileApIWS(IDbConnection connection, IVendor sqlDialect) : 
				base(connection, sqlDialect)
		{
			this.OnCreated();
		}
		
		public DVdPostMobileApIWS(IDbConnection connection, MappingSource mappingSource, IVendor sqlDialect) : 
				base(connection, mappingSource, sqlDialect)
		{
			this.OnCreated();
		}
	}
	#region End Not MONO_STRICT
	#endregion
#endif     // MONO_STRICT
	#endregion
	
	[Table(Name="plush_mobile.best_rated_movies")]
	public partial class BestRatedMovies
	{
		
		private System.Nullable<double> _average;
		
		private System.Nullable<decimal> _count;
		
		private System.Nullable<long> _diskID;
		
		private uint _imdBID;
		
		private int _languageID;
		
		private string _movieImage;
		
		private string _movieName;
		
		private System.Nullable<long> _rank;
		
		private System.Nullable<long> _seasonID;
		
		#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnAverageChanged();
		
		partial void OnAverageChanging(System.Nullable<double> value);
		
		partial void OnCountChanged();
		
		partial void OnCountChanging(System.Nullable<decimal> value);
		
		partial void OnDiskIDChanged();
		
		partial void OnDiskIDChanging(System.Nullable<long> value);
		
		partial void OnIMDbIDChanged();
		
		partial void OnIMDbIDChanging(uint value);
		
		partial void OnLanguageIDChanged();
		
		partial void OnLanguageIDChanging(int value);
		
		partial void OnMovieImageChanged();
		
		partial void OnMovieImageChanging(string value);
		
		partial void OnMovieNameChanged();
		
		partial void OnMovieNameChanging(string value);
		
		partial void OnRankChanged();
		
		partial void OnRankChanging(System.Nullable<long> value);
		
		partial void OnSeasonIDChanged();
		
		partial void OnSeasonIDChanging(System.Nullable<long> value);
		#endregion
		
		
		public BestRatedMovies()
		{
			this.OnCreated();
		}
		
		[Column(Storage="_average", Name="average", DbType="double", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<double> Average
		{
			get
			{
				return this._average;
			}
			set
			{
				if ((_average != value))
				{
					this.OnAverageChanging(value);
					this._average = value;
					this.OnAverageChanged();
				}
			}
		}
		
		[Column(Storage="_count", Name="count", DbType="decimal(32,0)", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<decimal> Count
		{
			get
			{
				return this._count;
			}
			set
			{
				if ((_count != value))
				{
					this.OnCountChanging(value);
					this._count = value;
					this.OnCountChanged();
				}
			}
		}
		
		[Column(Storage="_diskID", Name="disk_id", DbType="bigint", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<long> DiskID
		{
			get
			{
				return this._diskID;
			}
			set
			{
				if ((_diskID != value))
				{
					this.OnDiskIDChanging(value);
					this._diskID = value;
					this.OnDiskIDChanged();
				}
			}
		}
		
		[Column(Storage="_imdBID", Name="imdb_id", DbType="int unsigned", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public uint IMDbID
		{
			get
			{
				return this._imdBID;
			}
			set
			{
				if ((_imdBID != value))
				{
					this.OnIMDbIDChanging(value);
					this._imdBID = value;
					this.OnIMDbIDChanged();
				}
			}
		}
		
		[Column(Storage="_languageID", Name="language_id", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int LanguageID
		{
			get
			{
				return this._languageID;
			}
			set
			{
				if ((_languageID != value))
				{
					this.OnLanguageIDChanging(value);
					this._languageID = value;
					this.OnLanguageIDChanged();
				}
			}
		}
		
		[Column(Storage="_movieImage", Name="movie_image", DbType="varchar(50)", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public string MovieImage
		{
			get
			{
				return this._movieImage;
			}
			set
			{
				if (((_movieImage == value) 
							== false))
				{
					this.OnMovieImageChanging(value);
					this._movieImage = value;
					this.OnMovieImageChanged();
				}
			}
		}
		
		[Column(Storage="_movieName", Name="movie_name", DbType="varchar(64)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string MovieName
		{
			get
			{
				return this._movieName;
			}
			set
			{
				if (((_movieName == value) 
							== false))
				{
					this.OnMovieNameChanging(value);
					this._movieName = value;
					this.OnMovieNameChanged();
				}
			}
		}
		
		[Column(Storage="_rank", Name="rank", DbType="bigint(33)", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<long> Rank
		{
			get
			{
				return this._rank;
			}
			set
			{
				if ((_rank != value))
				{
					this.OnRankChanging(value);
					this._rank = value;
					this.OnRankChanged();
				}
			}
		}
		
		[Column(Storage="_seasonID", Name="season_id", DbType="bigint(12)", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<long> SeasonID
		{
			get
			{
				return this._seasonID;
			}
			set
			{
				if ((_seasonID != value))
				{
					this.OnSeasonIDChanging(value);
					this._seasonID = value;
					this.OnSeasonIDChanged();
				}
			}
		}
	}
	
	[Table(Name="plush_mobile.best_reviewers")]
	public partial class BestReviewers
	{
		
		private byte[] _avatar;
		
		private string _customersFirstName;
		
		private int _customersID;
		
		private string _customersLastName;
		
		private System.Nullable<int> _day;
		
		private string _kind;
		
		private string _nickname;
		
		private System.Nullable<int> _position;
		
		private System.Nullable<int> _rank;
		
		private int _ratingsCount;
		
		private int _reviewsCount;
		
		#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnAvatarChanged();
		
		partial void OnAvatarChanging(byte[] value);
		
		partial void OnCustomersFirstNameChanged();
		
		partial void OnCustomersFirstNameChanging(string value);
		
		partial void OnCustomersIDChanged();
		
		partial void OnCustomersIDChanging(int value);
		
		partial void OnCustomersLastNameChanged();
		
		partial void OnCustomersLastNameChanging(string value);
		
		partial void OnDayChanged();
		
		partial void OnDayChanging(System.Nullable<int> value);
		
		partial void OnKindChanged();
		
		partial void OnKindChanging(string value);
		
		partial void OnNicknameChanged();
		
		partial void OnNicknameChanging(string value);
		
		partial void OnPositionChanged();
		
		partial void OnPositionChanging(System.Nullable<int> value);
		
		partial void OnRankChanged();
		
		partial void OnRankChanging(System.Nullable<int> value);
		
		partial void OnRatingsCountChanged();
		
		partial void OnRatingsCountChanging(int value);
		
		partial void OnReviewsCountChanged();
		
		partial void OnReviewsCountChanging(int value);
		#endregion
		
		
		public BestReviewers()
		{
			this.OnCreated();
		}
		
		[Column(Storage="_avatar", Name="avatar", DbType="mediumblob", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public byte[] Avatar
		{
			get
			{
				return this._avatar;
			}
			set
			{
				if (((_avatar == value) 
							== false))
				{
					this.OnAvatarChanging(value);
					this._avatar = value;
					this.OnAvatarChanged();
				}
			}
		}
		
		[Column(Storage="_customersFirstName", Name="customers_firstname", DbType="varchar(32)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string CustomersFirstName
		{
			get
			{
				return this._customersFirstName;
			}
			set
			{
				if (((_customersFirstName == value) 
							== false))
				{
					this.OnCustomersFirstNameChanging(value);
					this._customersFirstName = value;
					this.OnCustomersFirstNameChanged();
				}
			}
		}
		
		[Column(Storage="_customersID", Name="customers_id", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int CustomersID
		{
			get
			{
				return this._customersID;
			}
			set
			{
				if ((_customersID != value))
				{
					this.OnCustomersIDChanging(value);
					this._customersID = value;
					this.OnCustomersIDChanged();
				}
			}
		}
		
		[Column(Storage="_customersLastName", Name="customers_lastname", DbType="varchar(32)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string CustomersLastName
		{
			get
			{
				return this._customersLastName;
			}
			set
			{
				if (((_customersLastName == value) 
							== false))
				{
					this.OnCustomersLastNameChanging(value);
					this._customersLastName = value;
					this.OnCustomersLastNameChanged();
				}
			}
		}
		
		[Column(Storage="_day", Name="day", DbType="int", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<int> Day
		{
			get
			{
				return this._day;
			}
			set
			{
				if ((_day != value))
				{
					this.OnDayChanging(value);
					this._day = value;
					this.OnDayChanged();
				}
			}
		}
		
		[Column(Storage="_kind", Name="Kind", DbType="varchar(15)", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public string Kind
		{
			get
			{
				return this._kind;
			}
			set
			{
				if (((_kind == value) 
							== false))
				{
					this.OnKindChanging(value);
					this._kind = value;
					this.OnKindChanged();
				}
			}
		}
		
		[Column(Storage="_nickname", Name="nickname", DbType="varchar(255)", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public string Nickname
		{
			get
			{
				return this._nickname;
			}
			set
			{
				if (((_nickname == value) 
							== false))
				{
					this.OnNicknameChanging(value);
					this._nickname = value;
					this.OnNicknameChanged();
				}
			}
		}
		
		[Column(Storage="_position", Name="position", DbType="int", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<int> Position
		{
			get
			{
				return this._position;
			}
			set
			{
				if ((_position != value))
				{
					this.OnPositionChanging(value);
					this._position = value;
					this.OnPositionChanged();
				}
			}
		}
		
		[Column(Storage="_rank", Name="rank", DbType="int", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<int> Rank
		{
			get
			{
				return this._rank;
			}
			set
			{
				if ((_rank != value))
				{
					this.OnRankChanging(value);
					this._rank = value;
					this.OnRankChanged();
				}
			}
		}
		
		[Column(Storage="_ratingsCount", Name="ratings_count", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int RatingsCount
		{
			get
			{
				return this._ratingsCount;
			}
			set
			{
				if ((_ratingsCount != value))
				{
					this.OnRatingsCountChanging(value);
					this._ratingsCount = value;
					this.OnRatingsCountChanged();
				}
			}
		}
		
		[Column(Storage="_reviewsCount", Name="reviews_count", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int ReviewsCount
		{
			get
			{
				return this._reviewsCount;
			}
			set
			{
				if ((_reviewsCount != value))
				{
					this.OnReviewsCountChanging(value);
					this._reviewsCount = value;
					this.OnReviewsCountChanged();
				}
			}
		}
	}
	
	[Table(Name="plush_mobile.best_reviews")]
	public partial class BestReviews
	{
		
		private int _customersBadRating;
		
		private int _customersBestRating;
		
		private System.Nullable<int> _customersID;
		
		private string _customersName;
		
		private System.Nullable<long> _diskID;
		
		private System.Nullable<int> _dvDPostRating;
		
		private uint _imdBID;
		
		private int _languagesID;
		
		private string _movieImage;
		
		private string _movieName;
		
		private string _nickname;
		
		private System.Nullable<int> _rank;
		
		private System.Nullable<int> _reviewsRating;
		
		private string _reviewsText;
		
		private System.Nullable<long> _seasonID;
		
		#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnCustomersBadRatingChanged();
		
		partial void OnCustomersBadRatingChanging(int value);
		
		partial void OnCustomersBestRatingChanged();
		
		partial void OnCustomersBestRatingChanging(int value);
		
		partial void OnCustomersIDChanged();
		
		partial void OnCustomersIDChanging(System.Nullable<int> value);
		
		partial void OnCustomersNameChanged();
		
		partial void OnCustomersNameChanging(string value);
		
		partial void OnDiskIDChanged();
		
		partial void OnDiskIDChanging(System.Nullable<long> value);
		
		partial void OnDVdPostRatingChanged();
		
		partial void OnDVdPostRatingChanging(System.Nullable<int> value);
		
		partial void OnIMDbIDChanged();
		
		partial void OnIMDbIDChanging(uint value);
		
		partial void OnLanguagesIDChanged();
		
		partial void OnLanguagesIDChanging(int value);
		
		partial void OnMovieImageChanged();
		
		partial void OnMovieImageChanging(string value);
		
		partial void OnMovieNameChanged();
		
		partial void OnMovieNameChanging(string value);
		
		partial void OnNicknameChanged();
		
		partial void OnNicknameChanging(string value);
		
		partial void OnRankChanged();
		
		partial void OnRankChanging(System.Nullable<int> value);
		
		partial void OnReviewsRatingChanged();
		
		partial void OnReviewsRatingChanging(System.Nullable<int> value);
		
		partial void OnReviewsTextChanged();
		
		partial void OnReviewsTextChanging(string value);
		
		partial void OnSeasonIDChanged();
		
		partial void OnSeasonIDChanging(System.Nullable<long> value);
		#endregion
		
		
		public BestReviews()
		{
			this.OnCreated();
		}
		
		[Column(Storage="_customersBadRating", Name="customers_bad_rating", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int CustomersBadRating
		{
			get
			{
				return this._customersBadRating;
			}
			set
			{
				if ((_customersBadRating != value))
				{
					this.OnCustomersBadRatingChanging(value);
					this._customersBadRating = value;
					this.OnCustomersBadRatingChanged();
				}
			}
		}
		
		[Column(Storage="_customersBestRating", Name="customers_best_rating", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int CustomersBestRating
		{
			get
			{
				return this._customersBestRating;
			}
			set
			{
				if ((_customersBestRating != value))
				{
					this.OnCustomersBestRatingChanging(value);
					this._customersBestRating = value;
					this.OnCustomersBestRatingChanged();
				}
			}
		}
		
		[Column(Storage="_customersID", Name="customers_id", DbType="int", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<int> CustomersID
		{
			get
			{
				return this._customersID;
			}
			set
			{
				if ((_customersID != value))
				{
					this.OnCustomersIDChanging(value);
					this._customersID = value;
					this.OnCustomersIDChanged();
				}
			}
		}
		
		[Column(Storage="_customersName", Name="customers_name", DbType="varchar(64)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string CustomersName
		{
			get
			{
				return this._customersName;
			}
			set
			{
				if (((_customersName == value) 
							== false))
				{
					this.OnCustomersNameChanging(value);
					this._customersName = value;
					this.OnCustomersNameChanged();
				}
			}
		}
		
		[Column(Storage="_diskID", Name="disk_id", DbType="bigint", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<long> DiskID
		{
			get
			{
				return this._diskID;
			}
			set
			{
				if ((_diskID != value))
				{
					this.OnDiskIDChanging(value);
					this._diskID = value;
					this.OnDiskIDChanged();
				}
			}
		}
		
		[Column(Storage="_dvDPostRating", Name="dvdpost_rating", DbType="int", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<int> DVdPostRating
		{
			get
			{
				return this._dvDPostRating;
			}
			set
			{
				if ((_dvDPostRating != value))
				{
					this.OnDVdPostRatingChanging(value);
					this._dvDPostRating = value;
					this.OnDVdPostRatingChanged();
				}
			}
		}
		
		[Column(Storage="_imdBID", Name="imdb_id", DbType="int unsigned", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public uint IMDbID
		{
			get
			{
				return this._imdBID;
			}
			set
			{
				if ((_imdBID != value))
				{
					this.OnIMDbIDChanging(value);
					this._imdBID = value;
					this.OnIMDbIDChanged();
				}
			}
		}
		
		[Column(Storage="_languagesID", Name="languages_id", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int LanguagesID
		{
			get
			{
				return this._languagesID;
			}
			set
			{
				if ((_languagesID != value))
				{
					this.OnLanguagesIDChanging(value);
					this._languagesID = value;
					this.OnLanguagesIDChanged();
				}
			}
		}
		
		[Column(Storage="_movieImage", Name="movie_image", DbType="varchar(50)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string MovieImage
		{
			get
			{
				return this._movieImage;
			}
			set
			{
				if (((_movieImage == value) 
							== false))
				{
					this.OnMovieImageChanging(value);
					this._movieImage = value;
					this.OnMovieImageChanged();
				}
			}
		}
		
		[Column(Storage="_movieName", Name="movie_name", DbType="varchar(64)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string MovieName
		{
			get
			{
				return this._movieName;
			}
			set
			{
				if (((_movieName == value) 
							== false))
				{
					this.OnMovieNameChanging(value);
					this._movieName = value;
					this.OnMovieNameChanged();
				}
			}
		}
		
		[Column(Storage="_nickname", Name="nickname", DbType="varchar(255)", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public string Nickname
		{
			get
			{
				return this._nickname;
			}
			set
			{
				if (((_nickname == value) 
							== false))
				{
					this.OnNicknameChanging(value);
					this._nickname = value;
					this.OnNicknameChanged();
				}
			}
		}
		
		[Column(Storage="_rank", Name="rank", DbType="int", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<int> Rank
		{
			get
			{
				return this._rank;
			}
			set
			{
				if ((_rank != value))
				{
					this.OnRankChanging(value);
					this._rank = value;
					this.OnRankChanged();
				}
			}
		}
		
		[Column(Storage="_reviewsRating", Name="reviews_rating", DbType="int(1)", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<int> ReviewsRating
		{
			get
			{
				return this._reviewsRating;
			}
			set
			{
				if ((_reviewsRating != value))
				{
					this.OnReviewsRatingChanging(value);
					this._reviewsRating = value;
					this.OnReviewsRatingChanged();
				}
			}
		}
		
		[Column(Storage="_reviewsText", Name="reviews_text", DbType="text", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string ReviewsText
		{
			get
			{
				return this._reviewsText;
			}
			set
			{
				if (((_reviewsText == value) 
							== false))
				{
					this.OnReviewsTextChanging(value);
					this._reviewsText = value;
					this.OnReviewsTextChanged();
				}
			}
		}
		
		[Column(Storage="_seasonID", Name="season_id", DbType="bigint(12)", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<long> SeasonID
		{
			get
			{
				return this._seasonID;
			}
			set
			{
				if ((_seasonID != value))
				{
					this.OnSeasonIDChanging(value);
					this._seasonID = value;
					this.OnSeasonIDChanged();
				}
			}
		}
	}
	
	[Table(Name="plush_mobile.catalog_community")]
	public partial class CatalogCommunity : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	{
		
		private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");
		
		private int _id;
		
		private string _image;
		
		private System.Nullable<int> _languageID;
		
		private string _name;
		
		private System.Nullable<int> _ordered;
		
		private string _refClient;
		
		private System.Nullable<int> _refClientID;
		
		private string _refSource;
		
		private System.Nullable<int> _refSourceID;
		
		#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnIDChanged();
		
		partial void OnIDChanging(int value);
		
		partial void OnImageChanged();
		
		partial void OnImageChanging(string value);
		
		partial void OnLanguageIDChanged();
		
		partial void OnLanguageIDChanging(System.Nullable<int> value);
		
		partial void OnNameChanged();
		
		partial void OnNameChanging(string value);
		
		partial void OnOrderedChanged();
		
		partial void OnOrderedChanging(System.Nullable<int> value);
		
		partial void OnRefClientChanged();
		
		partial void OnRefClientChanging(string value);
		
		partial void OnRefClientIDChanged();
		
		partial void OnRefClientIDChanging(System.Nullable<int> value);
		
		partial void OnRefSourceChanged();
		
		partial void OnRefSourceChanging(string value);
		
		partial void OnRefSourceIDChanged();
		
		partial void OnRefSourceIDChanging(System.Nullable<int> value);
		#endregion
		
		
		public CatalogCommunity()
		{
			this.OnCreated();
		}
		
		[Column(Storage="_id", Name="id", DbType="int", IsPrimaryKey=true, IsDbGenerated=true, AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int ID
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((_id != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_image", Name="image", DbType="varchar(100)", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public string Image
		{
			get
			{
				return this._image;
			}
			set
			{
				if (((_image == value) 
							== false))
				{
					this.OnImageChanging(value);
					this.SendPropertyChanging();
					this._image = value;
					this.SendPropertyChanged("Image");
					this.OnImageChanged();
				}
			}
		}
		
		[Column(Storage="_languageID", Name="language_id", DbType="int", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<int> LanguageID
		{
			get
			{
				return this._languageID;
			}
			set
			{
				if ((_languageID != value))
				{
					this.OnLanguageIDChanging(value);
					this.SendPropertyChanging();
					this._languageID = value;
					this.SendPropertyChanged("LanguageID");
					this.OnLanguageIDChanged();
				}
			}
		}
		
		[Column(Storage="_name", Name="name", DbType="varchar(100)", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public string Name
		{
			get
			{
				return this._name;
			}
			set
			{
				if (((_name == value) 
							== false))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[Column(Storage="_ordered", Name="ordered", DbType="int", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<int> Ordered
		{
			get
			{
				return this._ordered;
			}
			set
			{
				if ((_ordered != value))
				{
					this.OnOrderedChanging(value);
					this.SendPropertyChanging();
					this._ordered = value;
					this.SendPropertyChanged("Ordered");
					this.OnOrderedChanged();
				}
			}
		}
		
		[Column(Storage="_refClient", Name="ref_client", DbType="varchar(20)", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public string RefClient
		{
			get
			{
				return this._refClient;
			}
			set
			{
				if (((_refClient == value) 
							== false))
				{
					this.OnRefClientChanging(value);
					this.SendPropertyChanging();
					this._refClient = value;
					this.SendPropertyChanged("RefClient");
					this.OnRefClientChanged();
				}
			}
		}
		
		[Column(Storage="_refClientID", Name="ref_client_id", DbType="int", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<int> RefClientID
		{
			get
			{
				return this._refClientID;
			}
			set
			{
				if ((_refClientID != value))
				{
					this.OnRefClientIDChanging(value);
					this.SendPropertyChanging();
					this._refClientID = value;
					this.SendPropertyChanged("RefClientID");
					this.OnRefClientIDChanged();
				}
			}
		}
		
		[Column(Storage="_refSource", Name="ref_source", DbType="varchar(100)", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public string RefSource
		{
			get
			{
				return this._refSource;
			}
			set
			{
				if (((_refSource == value) 
							== false))
				{
					this.OnRefSourceChanging(value);
					this.SendPropertyChanging();
					this._refSource = value;
					this.SendPropertyChanged("RefSource");
					this.OnRefSourceChanged();
				}
			}
		}
		
		[Column(Storage="_refSourceID", Name="ref_source_id", DbType="int", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<int> RefSourceID
		{
			get
			{
				return this._refSourceID;
			}
			set
			{
				if ((_refSourceID != value))
				{
					this.OnRefSourceIDChanging(value);
					this.SendPropertyChanging();
					this._refSourceID = value;
					this.SendPropertyChanged("RefSourceID");
					this.OnRefSourceIDChanged();
				}
			}
		}
		
		public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
		
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
			if ((h != null))
			{
				h(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(string propertyName)
		{
			System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
			if ((h != null))
			{
				h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="plush_mobile.categories")]
	public partial class Categories
	{
		
		private string _active;
		
		private int _categoriesID;
		
		private string _categoriesImage;
		
		private string _categoriesName;
		
		private string _categoriesType;
		
		private System.Nullable<System.DateTime> _dateAdded;
		
		private System.Nullable<sbyte> _displayGroup;
		
		private int _languageID;
		
		private System.Nullable<System.DateTime> _lastModified;
		
		private int _parentID;
		
		private string _productType;
		
		private string _showHome;
		
		private int _size;
		
		private System.Nullable<int> _sortOrder;
		
		#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnActiveChanged();
		
		partial void OnActiveChanging(string value);
		
		partial void OnCategoriesIDChanged();
		
		partial void OnCategoriesIDChanging(int value);
		
		partial void OnCategoriesImageChanged();
		
		partial void OnCategoriesImageChanging(string value);
		
		partial void OnCategoriesNameChanged();
		
		partial void OnCategoriesNameChanging(string value);
		
		partial void OnCategoriesTypeChanged();
		
		partial void OnCategoriesTypeChanging(string value);
		
		partial void OnDateAddedChanged();
		
		partial void OnDateAddedChanging(System.Nullable<System.DateTime> value);
		
		partial void OnDisplayGroupChanged();
		
		partial void OnDisplayGroupChanging(System.Nullable<sbyte> value);
		
		partial void OnLanguageIDChanged();
		
		partial void OnLanguageIDChanging(int value);
		
		partial void OnLastModifiedChanged();
		
		partial void OnLastModifiedChanging(System.Nullable<System.DateTime> value);
		
		partial void OnParentIDChanged();
		
		partial void OnParentIDChanging(int value);
		
		partial void OnProductTypeChanged();
		
		partial void OnProductTypeChanging(string value);
		
		partial void OnShowHomeChanged();
		
		partial void OnShowHomeChanging(string value);
		
		partial void OnSizeChanged();
		
		partial void OnSizeChanging(int value);
		
		partial void OnSortOrderChanged();
		
		partial void OnSortOrderChanging(System.Nullable<int> value);
		#endregion
		
		
		public Categories()
		{
			this.OnCreated();
		}
		
		[Column(Storage="_active", Name="active", DbType="varchar(4)", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public string Active
		{
			get
			{
				return this._active;
			}
			set
			{
				if (((_active == value) 
							== false))
				{
					this.OnActiveChanging(value);
					this._active = value;
					this.OnActiveChanged();
				}
			}
		}
		
		[Column(Storage="_categoriesID", Name="categories_id", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int CategoriesID
		{
			get
			{
				return this._categoriesID;
			}
			set
			{
				if ((_categoriesID != value))
				{
					this.OnCategoriesIDChanging(value);
					this._categoriesID = value;
					this.OnCategoriesIDChanged();
				}
			}
		}
		
		[Column(Storage="_categoriesImage", Name="categories_image", DbType="varchar(64)", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public string CategoriesImage
		{
			get
			{
				return this._categoriesImage;
			}
			set
			{
				if (((_categoriesImage == value) 
							== false))
				{
					this.OnCategoriesImageChanging(value);
					this._categoriesImage = value;
					this.OnCategoriesImageChanged();
				}
			}
		}
		
		[Column(Storage="_categoriesName", Name="categories_name", DbType="varchar(64)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string CategoriesName
		{
			get
			{
				return this._categoriesName;
			}
			set
			{
				if (((_categoriesName == value) 
							== false))
				{
					this.OnCategoriesNameChanging(value);
					this._categoriesName = value;
					this.OnCategoriesNameChanged();
				}
			}
		}
		
		[Column(Storage="_categoriesType", Name="categories_type", DbType="varchar(10)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string CategoriesType
		{
			get
			{
				return this._categoriesType;
			}
			set
			{
				if (((_categoriesType == value) 
							== false))
				{
					this.OnCategoriesTypeChanging(value);
					this._categoriesType = value;
					this.OnCategoriesTypeChanged();
				}
			}
		}
		
		[Column(Storage="_dateAdded", Name="date_added", DbType="datetime", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<System.DateTime> DateAdded
		{
			get
			{
				return this._dateAdded;
			}
			set
			{
				if ((_dateAdded != value))
				{
					this.OnDateAddedChanging(value);
					this._dateAdded = value;
					this.OnDateAddedChanged();
				}
			}
		}
		
		[Column(Storage="_displayGroup", Name="display_group", DbType="tinyint(4)", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<sbyte> DisplayGroup
		{
			get
			{
				return this._displayGroup;
			}
			set
			{
				if ((_displayGroup != value))
				{
					this.OnDisplayGroupChanging(value);
					this._displayGroup = value;
					this.OnDisplayGroupChanged();
				}
			}
		}
		
		[Column(Storage="_languageID", Name="language_id", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int LanguageID
		{
			get
			{
				return this._languageID;
			}
			set
			{
				if ((_languageID != value))
				{
					this.OnLanguageIDChanging(value);
					this._languageID = value;
					this.OnLanguageIDChanged();
				}
			}
		}
		
		[Column(Storage="_lastModified", Name="last_modified", DbType="datetime", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<System.DateTime> LastModified
		{
			get
			{
				return this._lastModified;
			}
			set
			{
				if ((_lastModified != value))
				{
					this.OnLastModifiedChanging(value);
					this._lastModified = value;
					this.OnLastModifiedChanged();
				}
			}
		}
		
		[Column(Storage="_parentID", Name="parent_id", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int ParentID
		{
			get
			{
				return this._parentID;
			}
			set
			{
				if ((_parentID != value))
				{
					this.OnParentIDChanging(value);
					this._parentID = value;
					this.OnParentIDChanged();
				}
			}
		}
		
		[Column(Storage="_productType", Name="product_type", DbType="varchar(45)", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public string ProductType
		{
			get
			{
				return this._productType;
			}
			set
			{
				if (((_productType == value) 
							== false))
				{
					this.OnProductTypeChanging(value);
					this._productType = value;
					this.OnProductTypeChanged();
				}
			}
		}
		
		[Column(Storage="_showHome", Name="show_home", DbType="varchar(4)", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public string ShowHome
		{
			get
			{
				return this._showHome;
			}
			set
			{
				if (((_showHome == value) 
							== false))
				{
					this.OnShowHomeChanging(value);
					this._showHome = value;
					this.OnShowHomeChanged();
				}
			}
		}
		
		[Column(Storage="_size", Name="size", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int Size
		{
			get
			{
				return this._size;
			}
			set
			{
				if ((_size != value))
				{
					this.OnSizeChanging(value);
					this._size = value;
					this.OnSizeChanged();
				}
			}
		}
		
		[Column(Storage="_sortOrder", Name="sort_order", DbType="int(3)", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<int> SortOrder
		{
			get
			{
				return this._sortOrder;
			}
			set
			{
				if ((_sortOrder != value))
				{
					this.OnSortOrderChanging(value);
					this._sortOrder = value;
					this.OnSortOrderChanged();
				}
			}
		}
	}
	
	[Table(Name="plush_staging.credit_history")]
	public partial class CreditHistory
	{
		
		private System.Nullable<int> _aboType;
		
		private int _credit;
		
		private int _creditActionID;
		
		private System.Nullable<int> _creditFree;
		
		private int _creditPaid;
		
		private int _customersID;
		
		private System.DateTime _dateAdded;
		
		private uint _id;
		
		private System.Nullable<int> _ordersID;
		
		private System.Nullable<int> _quantityFree;
		
		private System.Nullable<int> _quantityPaid;
		
		private int _userModified;
		
		#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnAboTypeChanged();
		
		partial void OnAboTypeChanging(System.Nullable<int> value);
		
		partial void OnCreditChanged();
		
		partial void OnCreditChanging(int value);
		
		partial void OnCreditActionIDChanged();
		
		partial void OnCreditActionIDChanging(int value);
		
		partial void OnCreditFreeChanged();
		
		partial void OnCreditFreeChanging(System.Nullable<int> value);
		
		partial void OnCreditPaidChanged();
		
		partial void OnCreditPaidChanging(int value);
		
		partial void OnCustomersIDChanged();
		
		partial void OnCustomersIDChanging(int value);
		
		partial void OnDateAddedChanged();
		
		partial void OnDateAddedChanging(System.DateTime value);
		
		partial void OnIDChanged();
		
		partial void OnIDChanging(uint value);
		
		partial void OnOrdersIDChanged();
		
		partial void OnOrdersIDChanging(System.Nullable<int> value);
		
		partial void OnQuantityFreeChanged();
		
		partial void OnQuantityFreeChanging(System.Nullable<int> value);
		
		partial void OnQuantityPaidChanged();
		
		partial void OnQuantityPaidChanging(System.Nullable<int> value);
		
		partial void OnUserModifiedChanged();
		
		partial void OnUserModifiedChanging(int value);
		#endregion
		
		
		public CreditHistory()
		{
			this.OnCreated();
		}
		
		[Column(Storage="_aboType", Name="abo_type", DbType="int", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<int> AboType
		{
			get
			{
				return this._aboType;
			}
			set
			{
				if ((_aboType != value))
				{
					this.OnAboTypeChanging(value);
					this._aboType = value;
					this.OnAboTypeChanged();
				}
			}
		}
		
		[Column(Storage="_credit", Name="credit", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int Credit
		{
			get
			{
				return this._credit;
			}
			set
			{
				if ((_credit != value))
				{
					this.OnCreditChanging(value);
					this._credit = value;
					this.OnCreditChanged();
				}
			}
		}
		
		[Column(Storage="_creditActionID", Name="credit_action_id", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int CreditActionID
		{
			get
			{
				return this._creditActionID;
			}
			set
			{
				if ((_creditActionID != value))
				{
					this.OnCreditActionIDChanging(value);
					this._creditActionID = value;
					this.OnCreditActionIDChanged();
				}
			}
		}
		
		[Column(Storage="_creditFree", Name="credit_free", DbType="int", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<int> CreditFree
		{
			get
			{
				return this._creditFree;
			}
			set
			{
				if ((_creditFree != value))
				{
					this.OnCreditFreeChanging(value);
					this._creditFree = value;
					this.OnCreditFreeChanged();
				}
			}
		}
		
		[Column(Storage="_creditPaid", Name="credit_paid", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int CreditPaid
		{
			get
			{
				return this._creditPaid;
			}
			set
			{
				if ((_creditPaid != value))
				{
					this.OnCreditPaidChanging(value);
					this._creditPaid = value;
					this.OnCreditPaidChanged();
				}
			}
		}
		
		[Column(Storage="_customersID", Name="customers_id", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int CustomersID
		{
			get
			{
				return this._customersID;
			}
			set
			{
				if ((_customersID != value))
				{
					this.OnCustomersIDChanging(value);
					this._customersID = value;
					this.OnCustomersIDChanged();
				}
			}
		}
		
		[Column(Storage="_dateAdded", Name="date_added", DbType="timestamp", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public System.DateTime DateAdded
		{
			get
			{
				return this._dateAdded;
			}
			set
			{
				if ((_dateAdded != value))
				{
					this.OnDateAddedChanging(value);
					this._dateAdded = value;
					this.OnDateAddedChanged();
				}
			}
		}
		
		[Column(Storage="_id", Name="id", DbType="int unsigned", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public uint ID
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((_id != value))
				{
					this.OnIDChanging(value);
					this._id = value;
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_ordersID", Name="orders_id", DbType="int", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<int> OrdersID
		{
			get
			{
				return this._ordersID;
			}
			set
			{
				if ((_ordersID != value))
				{
					this.OnOrdersIDChanging(value);
					this._ordersID = value;
					this.OnOrdersIDChanged();
				}
			}
		}
		
		[Column(Storage="_quantityFree", Name="quantity_free", DbType="int", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<int> QuantityFree
		{
			get
			{
				return this._quantityFree;
			}
			set
			{
				if ((_quantityFree != value))
				{
					this.OnQuantityFreeChanging(value);
					this._quantityFree = value;
					this.OnQuantityFreeChanged();
				}
			}
		}
		
		[Column(Storage="_quantityPaid", Name="quantity_paid", DbType="int", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<int> QuantityPaid
		{
			get
			{
				return this._quantityPaid;
			}
			set
			{
				if ((_quantityPaid != value))
				{
					this.OnQuantityPaidChanging(value);
					this._quantityPaid = value;
					this.OnQuantityPaidChanged();
				}
			}
		}
		
		[Column(Storage="_userModified", Name="user_modified", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int UserModified
		{
			get
			{
				return this._userModified;
			}
			set
			{
				if ((_userModified != value))
				{
					this.OnUserModifiedChanging(value);
					this._userModified = value;
					this.OnUserModifiedChanged();
				}
			}
		}
	}
	
    //[Table(Name="plush_mobile.hp_categories")]
    //public partial class HpCategories : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    //{
		
    //    private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");
		
    //    private int _id;
		
    //    private string _image;
		
    //    private System.Nullable<int> _languageID;
		
    //    private string _name;
		
    //    private System.Nullable<int> _ordered;
		
    //    private string _refClient;
		
    //    private System.Nullable<int> _refClientID;
		
    //    private string _refSource;
		
    //    private System.Nullable<int> _refSourceID;
		
    //    #region Extensibility Method Declarations
    //    partial void OnCreated();
		
    //    partial void OnIDChanged();
		
    //    partial void OnIDChanging(int value);
		
    //    partial void OnImageChanged();
		
    //    partial void OnImageChanging(string value);
		
    //    partial void OnLanguageIDChanged();
		
    //    partial void OnLanguageIDChanging(System.Nullable<int> value);
		
    //    partial void OnNameChanged();
		
    //    partial void OnNameChanging(string value);
		
    //    partial void OnOrderedChanged();
		
    //    partial void OnOrderedChanging(System.Nullable<int> value);
		
    //    partial void OnRefClientChanged();
		
    //    partial void OnRefClientChanging(string value);
		
    //    partial void OnRefClientIDChanged();
		
    //    partial void OnRefClientIDChanging(System.Nullable<int> value);
		
    //    partial void OnRefSourceChanged();
		
    //    partial void OnRefSourceChanging(string value);
		
    //    partial void OnRefSourceIDChanged();
		
    //    partial void OnRefSourceIDChanging(System.Nullable<int> value);
    //    #endregion
		
		
    //    public HpCategories()
    //    {
    //        this.OnCreated();
    //    }
		
    //    [Column(Storage="_id", Name="id", DbType="int", IsPrimaryKey=true, IsDbGenerated=true, AutoSync=AutoSync.Never, CanBeNull=false)]
    //    [DebuggerNonUserCode()]
    //    public int ID
    //    {
    //        get
    //        {
    //            return this._id;
    //        }
    //        set
    //        {
    //            if ((_id != value))
    //            {
    //                this.OnIDChanging(value);
    //                this.SendPropertyChanging();
    //                this._id = value;
    //                this.SendPropertyChanged("ID");
    //                this.OnIDChanged();
    //            }
    //        }
    //    }
		
    //    [Column(Storage="_image", Name="image", DbType="varchar(100)", AutoSync=AutoSync.Never)]
    //    [DebuggerNonUserCode()]
    //    public string Image
    //    {
    //        get
    //        {
    //            return this._image;
    //        }
    //        set
    //        {
    //            if (((_image == value) 
    //                        == false))
    //            {
    //                this.OnImageChanging(value);
    //                this.SendPropertyChanging();
    //                this._image = value;
    //                this.SendPropertyChanged("Image");
    //                this.OnImageChanged();
    //            }
    //        }
    //    }
		
    //    [Column(Storage="_languageID", Name="language_id", DbType="int", AutoSync=AutoSync.Never)]
    //    [DebuggerNonUserCode()]
    //    public System.Nullable<int> LanguageID
    //    {
    //        get
    //        {
    //            return this._languageID;
    //        }
    //        set
    //        {
    //            if ((_languageID != value))
    //            {
    //                this.OnLanguageIDChanging(value);
    //                this.SendPropertyChanging();
    //                this._languageID = value;
    //                this.SendPropertyChanged("LanguageID");
    //                this.OnLanguageIDChanged();
    //            }
    //        }
    //    }
		
    //    [Column(Storage="_name", Name="name", DbType="varchar(100)", AutoSync=AutoSync.Never)]
    //    [DebuggerNonUserCode()]
    //    public string Name
    //    {
    //        get
    //        {
    //            return this._name;
    //        }
    //        set
    //        {
    //            if (((_name == value) 
    //                        == false))
    //            {
    //                this.OnNameChanging(value);
    //                this.SendPropertyChanging();
    //                this._name = value;
    //                this.SendPropertyChanged("Name");
    //                this.OnNameChanged();
    //            }
    //        }
    //    }
		
    //    [Column(Storage="_ordered", Name="ordered", DbType="int", AutoSync=AutoSync.Never)]
    //    [DebuggerNonUserCode()]
    //    public System.Nullable<int> Ordered
    //    {
    //        get
    //        {
    //            return this._ordered;
    //        }
    //        set
    //        {
    //            if ((_ordered != value))
    //            {
    //                this.OnOrderedChanging(value);
    //                this.SendPropertyChanging();
    //                this._ordered = value;
    //                this.SendPropertyChanged("Ordered");
    //                this.OnOrderedChanged();
    //            }
    //        }
    //    }
		
    //    [Column(Storage="_refClient", Name="ref_client", DbType="varchar(20)", AutoSync=AutoSync.Never)]
    //    [DebuggerNonUserCode()]
    //    public string RefClient
    //    {
    //        get
    //        {
    //            return this._refClient;
    //        }
    //        set
    //        {
    //            if (((_refClient == value) 
    //                        == false))
    //            {
    //                this.OnRefClientChanging(value);
    //                this.SendPropertyChanging();
    //                this._refClient = value;
    //                this.SendPropertyChanged("RefClient");
    //                this.OnRefClientChanged();
    //            }
    //        }
    //    }
		
    //    [Column(Storage="_refClientID", Name="ref_client_id", DbType="int", AutoSync=AutoSync.Never)]
    //    [DebuggerNonUserCode()]
    //    public System.Nullable<int> RefClientID
    //    {
    //        get
    //        {
    //            return this._refClientID;
    //        }
    //        set
    //        {
    //            if ((_refClientID != value))
    //            {
    //                this.OnRefClientIDChanging(value);
    //                this.SendPropertyChanging();
    //                this._refClientID = value;
    //                this.SendPropertyChanged("RefClientID");
    //                this.OnRefClientIDChanged();
    //            }
    //        }
    //    }
		
    //    [Column(Storage="_refSource", Name="ref_source", DbType="varchar(100)", AutoSync=AutoSync.Never)]
    //    [DebuggerNonUserCode()]
    //    public string RefSource
    //    {
    //        get
    //        {
    //            return this._refSource;
    //        }
    //        set
    //        {
    //            if (((_refSource == value) 
    //                        == false))
    //            {
    //                this.OnRefSourceChanging(value);
    //                this.SendPropertyChanging();
    //                this._refSource = value;
    //                this.SendPropertyChanged("RefSource");
    //                this.OnRefSourceChanged();
    //            }
    //        }
    //    }
		
    //    [Column(Storage="_refSourceID", Name="ref_source_id", DbType="int", AutoSync=AutoSync.Never)]
    //    [DebuggerNonUserCode()]
    //    public System.Nullable<int> RefSourceID
    //    {
    //        get
    //        {
    //            return this._refSourceID;
    //        }
    //        set
    //        {
    //            if ((_refSourceID != value))
    //            {
    //                this.OnRefSourceIDChanging(value);
    //                this.SendPropertyChanging();
    //                this._refSourceID = value;
    //                this.SendPropertyChanged("RefSourceID");
    //                this.OnRefSourceIDChanged();
    //            }
    //        }
    //    }
		
    //    public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
		
    //    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		
    //    protected virtual void SendPropertyChanging()
    //    {
    //        System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
    //        if ((h != null))
    //        {
    //            h(this, emptyChangingEventArgs);
    //        }
    //    }
		
    //    protected virtual void SendPropertyChanged(string propertyName)
    //    {
    //        System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
    //        if ((h != null))
    //        {
    //            h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
    //        }
    //    }
    //}

    [Table(Name = "plush_mobile.hp_categories")]
    public partial class HpCategories : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private System.Nullable<sbyte> _available;

        private int _id;

        private string _image;

        private System.Nullable<int> _languageID;

        private string _name;

        private System.Nullable<int> _ordered;

        private string _refClient;

        private System.Nullable<int> _refClientID;

        private string _refSource;

        private System.Nullable<int> _refSourceID;

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnAvailableChanged();

        partial void OnAvailableChanging(System.Nullable<sbyte> value);

        partial void OnIDChanged();

        partial void OnIDChanging(int value);

        partial void OnImageChanged();

        partial void OnImageChanging(string value);

        partial void OnLanguageIDChanged();

        partial void OnLanguageIDChanging(System.Nullable<int> value);

        partial void OnNameChanged();

        partial void OnNameChanging(string value);

        partial void OnOrderedChanged();

        partial void OnOrderedChanging(System.Nullable<int> value);

        partial void OnRefClientChanged();

        partial void OnRefClientChanging(string value);

        partial void OnRefClientIDChanged();

        partial void OnRefClientIDChanging(System.Nullable<int> value);

        partial void OnRefSourceChanged();

        partial void OnRefSourceChanging(string value);

        partial void OnRefSourceIDChanged();

        partial void OnRefSourceIDChanging(System.Nullable<int> value);
        #endregion


        public HpCategories()
        {
            this.OnCreated();
        }

        [Column(Storage = "_available", Name = "available", DbType = "tinyint(4)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> Available
        {
            get
            {
                return this._available;
            }
            set
            {
                if ((_available != value))
                {
                    this.OnAvailableChanging(value);
                    this.SendPropertyChanging();
                    this._available = value;
                    this.SendPropertyChanged("Available");
                    this.OnAvailableChanged();
                }
            }
        }

        [Column(Storage = "_id", Name = "id", DbType = "int", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int ID
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((_id != value))
                {
                    this.OnIDChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("ID");
                    this.OnIDChanged();
                }
            }
        }

        [Column(Storage = "_image", Name = "image", DbType = "varchar(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string Image
        {
            get
            {
                return this._image;
            }
            set
            {
                if (((_image == value)
                            == false))
                {
                    this.OnImageChanging(value);
                    this.SendPropertyChanging();
                    this._image = value;
                    this.SendPropertyChanged("Image");
                    this.OnImageChanged();
                }
            }
        }

        [Column(Storage = "_languageID", Name = "language_id", DbType = "int", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> LanguageID
        {
            get
            {
                return this._languageID;
            }
            set
            {
                if ((_languageID != value))
                {
                    this.OnLanguageIDChanging(value);
                    this.SendPropertyChanging();
                    this._languageID = value;
                    this.SendPropertyChanged("LanguageID");
                    this.OnLanguageIDChanged();
                }
            }
        }

        [Column(Storage = "_name", Name = "name", DbType = "varchar(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                if (((_name == value)
                            == false))
                {
                    this.OnNameChanging(value);
                    this.SendPropertyChanging();
                    this._name = value;
                    this.SendPropertyChanged("Name");
                    this.OnNameChanged();
                }
            }
        }

        [Column(Storage = "_ordered", Name = "ordered", DbType = "int", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> Ordered
        {
            get
            {
                return this._ordered;
            }
            set
            {
                if ((_ordered != value))
                {
                    this.OnOrderedChanging(value);
                    this.SendPropertyChanging();
                    this._ordered = value;
                    this.SendPropertyChanged("Ordered");
                    this.OnOrderedChanged();
                }
            }
        }

        [Column(Storage = "_refClient", Name = "ref_client", DbType = "varchar(20)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string RefClient
        {
            get
            {
                return this._refClient;
            }
            set
            {
                if (((_refClient == value)
                            == false))
                {
                    this.OnRefClientChanging(value);
                    this.SendPropertyChanging();
                    this._refClient = value;
                    this.SendPropertyChanged("RefClient");
                    this.OnRefClientChanged();
                }
            }
        }

        [Column(Storage = "_refClientID", Name = "ref_client_id", DbType = "int", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> RefClientID
        {
            get
            {
                return this._refClientID;
            }
            set
            {
                if ((_refClientID != value))
                {
                    this.OnRefClientIDChanging(value);
                    this.SendPropertyChanging();
                    this._refClientID = value;
                    this.SendPropertyChanged("RefClientID");
                    this.OnRefClientIDChanged();
                }
            }
        }

        [Column(Storage = "_refSource", Name = "ref_source", DbType = "varchar(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string RefSource
        {
            get
            {
                return this._refSource;
            }
            set
            {
                if (((_refSource == value)
                            == false))
                {
                    this.OnRefSourceChanging(value);
                    this.SendPropertyChanging();
                    this._refSource = value;
                    this.SendPropertyChanged("RefSource");
                    this.OnRefSourceChanged();
                }
            }
        }

        [Column(Storage = "_refSourceID", Name = "ref_source_id", DbType = "int", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> RefSourceID
        {
            get
            {
                return this._refSourceID;
            }
            set
            {
                if ((_refSourceID != value))
                {
                    this.OnRefSourceIDChanging(value);
                    this.SendPropertyChanging();
                    this._refSourceID = value;
                    this.SendPropertyChanged("RefSourceID");
                    this.OnRefSourceIDChanged();
                }
            }
        }

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
	
	[Table(Name="plush_mobile.hp_movie")]
	public partial class HpMovie
	{
		
		private string _awards;
		
		private string _broadcast;
		
		private string _dcRp;
		
		private System.Nullable<int> _diskID;
		
		private int _id;
		
		private int _imdBIdseRie;
		
		private string _imG;
		
		private string _kind;
		
		private System.Nullable<int> _lngID;
		
		private string _name;
		
		private System.Nullable<int> _ordered;
		
		private System.Nullable<decimal> _rate;
		
		private System.Nullable<int> _seasonID;
		
		private string _trailer;
		
		private System.Nullable<int> _voD;
		
		#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnAwardsChanged();
		
		partial void OnAwardsChanging(string value);
		
		partial void OnBroadcastChanged();
		
		partial void OnBroadcastChanging(string value);
		
		partial void OnDcRpChanged();
		
		partial void OnDcRpChanging(string value);
		
		partial void OnDiskIDChanged();
		
		partial void OnDiskIDChanging(System.Nullable<int> value);
		
		partial void OnIDChanged();
		
		partial void OnIDChanging(int value);
		
		partial void OnIMDbIDSErieChanged();
		
		partial void OnIMDbIDSErieChanging(System.Nullable<int> value);
		
		partial void OnIMgChanged();
		
		partial void OnIMgChanging(string value);
		
		partial void OnKindChanged();
		
		partial void OnKindChanging(string value);
		
		partial void OnLNGiDChanged();
		
		partial void OnLNGiDChanging(System.Nullable<int> value);
		
		partial void OnNameChanged();
		
		partial void OnNameChanging(string value);
		
		partial void OnOrderedChanged();
		
		partial void OnOrderedChanging(System.Nullable<int> value);
		
		partial void OnRateChanged();
		
		partial void OnRateChanging(System.Nullable<decimal> value);
		
		partial void OnSeasonIDChanged();
		
		partial void OnSeasonIDChanging(System.Nullable<int> value);
		
		partial void OnTrailerChanged();
		
		partial void OnTrailerChanging(string value);
		
		partial void OnVOdChanged();
		
		partial void OnVOdChanging(System.Nullable<int> value);
		#endregion
		
		
		public HpMovie()
		{
			this.OnCreated();
		}
		
		[Column(Storage="_awards", Name="awards", DbType="text", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public string Awards
		{
			get
			{
				return this._awards;
			}
			set
			{
				if (((_awards == value) 
							== false))
				{
					this.OnAwardsChanging(value);
					this._awards = value;
					this.OnAwardsChanged();
				}
			}
		}
		
		[Column(Storage="_broadcast", Name="broadcast", DbType="varchar(40)", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public string Broadcast
		{
			get
			{
				return this._broadcast;
			}
			set
			{
				if (((_broadcast == value) 
							== false))
				{
					this.OnBroadcastChanging(value);
					this._broadcast = value;
					this.OnBroadcastChanged();
				}
			}
		}
		
		[Column(Storage="_dcRp", Name="dcrp", DbType="text", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public string DcRp
		{
			get
			{
				return this._dcRp;
			}
			set
			{
				if (((_dcRp == value) 
							== false))
				{
					this.OnDcRpChanging(value);
					this._dcRp = value;
					this.OnDcRpChanged();
				}
			}
		}
		
		[Column(Storage="_diskID", Name="disk_id", DbType="int", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<int> DiskID
		{
			get
			{
				return this._diskID;
			}
			set
			{
				if ((_diskID != value))
				{
					this.OnDiskIDChanging(value);
					this._diskID = value;
					this.OnDiskIDChanged();
				}
			}
		}
		
		[Column(Storage="_id", Name="id", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int ID
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((_id != value))
				{
					this.OnIDChanging(value);
					this._id = value;
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_imdBIdseRie", Name="imdb_id_serie", DbType="int(10)", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public int IMDbIDSErie
		{
			get
			{
				return this._imdBIdseRie;
			}
			set
			{
				if ((_imdBIdseRie != value))
				{
					this.OnIMDbIDSErieChanging(value);
					this._imdBIdseRie = value;
					this.OnIMDbIDSErieChanged();
				}
			}
		}
		
		[Column(Storage="_imG", Name="img", DbType="varchar(50)", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public string IMg
		{
			get
			{
				return this._imG;
			}
			set
			{
				if (((_imG == value) 
							== false))
				{
					this.OnIMgChanging(value);
					this._imG = value;
					this.OnIMgChanged();
				}
			}
		}
		
		[Column(Storage="_kind", Name="kind", DbType="varchar(20)", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public string Kind
		{
			get
			{
				return this._kind;
			}
			set
			{
				if (((_kind == value) 
							== false))
				{
					this.OnKindChanging(value);
					this._kind = value;
					this.OnKindChanged();
				}
			}
		}
		
		[Column(Storage="_lngID", Name="lngid", DbType="int", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<int> LNGiD
		{
			get
			{
				return this._lngID;
			}
			set
			{
				if ((_lngID != value))
				{
					this.OnLNGiDChanging(value);
					this._lngID = value;
					this.OnLNGiDChanged();
				}
			}
		}
		
		[Column(Storage="_name", Name="name", DbType="varchar(64)", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public string Name
		{
			get
			{
				return this._name;
			}
			set
			{
				if (((_name == value) 
							== false))
				{
					this.OnNameChanging(value);
					this._name = value;
					this.OnNameChanged();
				}
			}
		}
		
		[Column(Storage="_ordered", Name="ordered", DbType="int", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<int> Ordered
		{
			get
			{
				return this._ordered;
			}
			set
			{
				if ((_ordered != value))
				{
					this.OnOrderedChanging(value);
					this._ordered = value;
					this.OnOrderedChanged();
				}
			}
		}
		
		[Column(Storage="_rate", Name="rate", DbType="decimal(2,1)", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<decimal> Rate
		{
			get
			{
				return this._rate;
			}
			set
			{
				if ((_rate != value))
				{
					this.OnRateChanging(value);
					this._rate = value;
					this.OnRateChanged();
				}
			}
		}
		
		[Column(Storage="_seasonID", Name="season_id", DbType="int", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<int> SeasonID
		{
			get
			{
				return this._seasonID;
			}
			set
			{
				if ((_seasonID != value))
				{
					this.OnSeasonIDChanging(value);
					this._seasonID = value;
					this.OnSeasonIDChanged();
				}
			}
		}
		
		[Column(Storage="_trailer", Name="trailer", DbType="text", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public string Trailer
		{
			get
			{
				return this._trailer;
			}
			set
			{
				if (((_trailer == value) 
							== false))
				{
					this.OnTrailerChanging(value);
					this._trailer = value;
					this.OnTrailerChanged();
				}
			}
		}
		
		[Column(Storage="_voD", Name="vod", DbType="int", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<int> VOd
		{
			get
			{
				return this._voD;
			}
			set
			{
				if ((_voD != value))
				{
					this.OnVOdChanging(value);
					this._voD = value;
					this.OnVOdChanged();
				}
			}
		}
	}
	
	[Table(Name="plush_mobile.hp_top_theme")]
	public partial class HpTopTheme
	{
		
		private int _id;
		
		private string _kind;
		
		private System.Nullable<int> _lngID;
		
		private string _name;
		
		private System.Nullable<int> _ordered;
		
		private System.Nullable<int> _topThemeID;
		
		#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnIDChanged();
		
		partial void OnIDChanging(int value);
		
		partial void OnKindChanged();
		
		partial void OnKindChanging(string value);
		
		partial void OnLNGiDChanged();
		
		partial void OnLNGiDChanging(System.Nullable<int> value);
		
		partial void OnNameChanged();
		
		partial void OnNameChanging(string value);
		
		partial void OnOrderedChanged();
		
		partial void OnOrderedChanging(System.Nullable<int> value);
		
		partial void OnTopThemeIDChanged();
		
		partial void OnTopThemeIDChanging(System.Nullable<int> value);
		#endregion
		
		
		public HpTopTheme()
		{
			this.OnCreated();
		}
		
		[Column(Storage="_id", Name="id", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int ID
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((_id != value))
				{
					this.OnIDChanging(value);
					this._id = value;
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_kind", Name="kind", DbType="varchar(30)", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public string Kind
		{
			get
			{
				return this._kind;
			}
			set
			{
				if (((_kind == value) 
							== false))
				{
					this.OnKindChanging(value);
					this._kind = value;
					this.OnKindChanged();
				}
			}
		}
		
		[Column(Storage="_lngID", Name="lngid", DbType="int", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<int> LNGiD
		{
			get
			{
				return this._lngID;
			}
			set
			{
				if ((_lngID != value))
				{
					this.OnLNGiDChanging(value);
					this._lngID = value;
					this.OnLNGiDChanged();
				}
			}
		}
		
		[Column(Storage="_name", Name="name", DbType="varchar(255)", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public string Name
		{
			get
			{
				return this._name;
			}
			set
			{
				if (((_name == value) 
							== false))
				{
					this.OnNameChanging(value);
					this._name = value;
					this.OnNameChanged();
				}
			}
		}
		
		[Column(Storage="_ordered", Name="ordered", DbType="int", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<int> Ordered
		{
			get
			{
				return this._ordered;
			}
			set
			{
				if ((_ordered != value))
				{
					this.OnOrderedChanging(value);
					this._ordered = value;
					this.OnOrderedChanged();
				}
			}
		}
		
		[Column(Storage="_topThemeID", Name="topthemeid", DbType="int", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<int> TopThemeID
		{
			get
			{
				return this._topThemeID;
			}
			set
			{
				if ((_topThemeID != value))
				{
					this.OnTopThemeIDChanging(value);
					this._topThemeID = value;
					this.OnTopThemeIDChanged();
				}
			}
		}
	}
	
	[Table(Name="plush_mobile.most_discused_movies")]
	public partial class MostDiscusEdMovies
	{
		
		private float _average;
		
		private int _count;
		
		private System.Nullable<long> _diskID;
		
		private uint _imdBID;
		
		private int _languageID;
		
		private System.Nullable<int> _mindEr;
		
		private string _movieImage;
		
		private string _movieName;
		
		private System.Nullable<int> _plus;
		
		private System.Nullable<int> _rank;
		
		private System.Nullable<long> _seasonID;
		
		#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnAverageChanged();
		
		partial void OnAverageChanging(float value);
		
		partial void OnCountChanged();
		
		partial void OnCountChanging(int value);
		
		partial void OnDiskIDChanged();
		
		partial void OnDiskIDChanging(System.Nullable<long> value);
		
		partial void OnIMDbIDChanged();
		
		partial void OnIMDbIDChanging(uint value);
		
		partial void OnLanguageIDChanged();
		
		partial void OnLanguageIDChanging(int value);
		
		partial void OnMindERChanged();
		
		partial void OnMindERChanging(System.Nullable<int> value);
		
		partial void OnMovieImageChanged();
		
		partial void OnMovieImageChanging(string value);
		
		partial void OnMovieNameChanged();
		
		partial void OnMovieNameChanging(string value);
		
		partial void OnPlusChanged();
		
		partial void OnPlusChanging(System.Nullable<int> value);
		
		partial void OnRankChanged();
		
		partial void OnRankChanging(System.Nullable<int> value);
		
		partial void OnSeasonIDChanged();
		
		partial void OnSeasonIDChanging(System.Nullable<long> value);
		#endregion
		
		
		public MostDiscusEdMovies()
		{
			this.OnCreated();
		}
		
		[Column(Storage="_average", Name="average", DbType="float", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public float Average
		{
			get
			{
				return this._average;
			}
			set
			{
				if ((_average != value))
				{
					this.OnAverageChanging(value);
					this._average = value;
					this.OnAverageChanged();
				}
			}
		}
		
		[Column(Storage="_count", Name="count", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int Count
		{
			get
			{
				return this._count;
			}
			set
			{
				if ((_count != value))
				{
					this.OnCountChanging(value);
					this._count = value;
					this.OnCountChanged();
				}
			}
		}
		
		[Column(Storage="_diskID", Name="disk_id", DbType="bigint", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<long> DiskID
		{
			get
			{
				return this._diskID;
			}
			set
			{
				if ((_diskID != value))
				{
					this.OnDiskIDChanging(value);
					this._diskID = value;
					this.OnDiskIDChanged();
				}
			}
		}
		
		[Column(Storage="_imdBID", Name="imdb_id", DbType="int unsigned", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public uint IMDbID
		{
			get
			{
				return this._imdBID;
			}
			set
			{
				if ((_imdBID != value))
				{
					this.OnIMDbIDChanging(value);
					this._imdBID = value;
					this.OnIMDbIDChanged();
				}
			}
		}
		
		[Column(Storage="_languageID", Name="language_id", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int LanguageID
		{
			get
			{
				return this._languageID;
			}
			set
			{
				if ((_languageID != value))
				{
					this.OnLanguageIDChanging(value);
					this._languageID = value;
					this.OnLanguageIDChanged();
				}
			}
		}
		
		[Column(Storage="_mindEr", Name="minder", DbType="int", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<int> MindER
		{
			get
			{
				return this._mindEr;
			}
			set
			{
				if ((_mindEr != value))
				{
					this.OnMindERChanging(value);
					this._mindEr = value;
					this.OnMindERChanged();
				}
			}
		}
		
		[Column(Storage="_movieImage", Name="movie_image", DbType="varchar(50)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string MovieImage
		{
			get
			{
				return this._movieImage;
			}
			set
			{
				if (((_movieImage == value) 
							== false))
				{
					this.OnMovieImageChanging(value);
					this._movieImage = value;
					this.OnMovieImageChanged();
				}
			}
		}
		
		[Column(Storage="_movieName", Name="movie_name", DbType="varchar(64)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string MovieName
		{
			get
			{
				return this._movieName;
			}
			set
			{
				if (((_movieName == value) 
							== false))
				{
					this.OnMovieNameChanging(value);
					this._movieName = value;
					this.OnMovieNameChanged();
				}
			}
		}
		
		[Column(Storage="_plus", Name="plus", DbType="int", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<int> Plus
		{
			get
			{
				return this._plus;
			}
			set
			{
				if ((_plus != value))
				{
					this.OnPlusChanging(value);
					this._plus = value;
					this.OnPlusChanged();
				}
			}
		}
		
		[Column(Storage="_rank", Name="rank", DbType="int", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<int> Rank
		{
			get
			{
				return this._rank;
			}
			set
			{
				if ((_rank != value))
				{
					this.OnRankChanging(value);
					this._rank = value;
					this.OnRankChanged();
				}
			}
		}
		
		[Column(Storage="_seasonID", Name="season_id", DbType="bigint(12)", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<long> SeasonID
		{
			get
			{
				return this._seasonID;
			}
			set
			{
				if ((_seasonID != value))
				{
					this.OnSeasonIDChanging(value);
					this._seasonID = value;
					this.OnSeasonIDChanged();
				}
			}
		}
	}
	
	[Table(Name="plush_mobile.most_rented_movies")]
	public partial class MostRentedMovies
	{
		
		private string _broadcast;
		
		private string _dcRp;
		
		private System.Nullable<int> _diskID;
		
		private System.Nullable<uint> _imdBIdseRie;
		
		private string _imG;
		
		private System.Nullable<int> _lngID;
		
		private string _name;
		
		private System.Nullable<decimal> _rate;
		
		private System.Nullable<decimal> _seasonID;
		
		private string _trailer;
		
		private System.Nullable<int> _voD;
		
		#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnBroadcastChanged();
		
		partial void OnBroadcastChanging(string value);
		
		partial void OnDcRpChanged();
		
		partial void OnDcRpChanging(string value);
		
		partial void OnDiskIDChanged();
		
		partial void OnDiskIDChanging(System.Nullable<int> value);
		
		partial void OnIMDbIDSErieChanged();
		
		partial void OnIMDbIDSErieChanging(System.Nullable<uint> value);
		
		partial void OnIMgChanged();
		
		partial void OnIMgChanging(string value);
		
		partial void OnLNGiDChanged();
		
		partial void OnLNGiDChanging(System.Nullable<int> value);
		
		partial void OnNameChanged();
		
		partial void OnNameChanging(string value);
		
		partial void OnRateChanged();
		
		partial void OnRateChanging(System.Nullable<decimal> value);
		
		partial void OnSeasonIDChanged();
		
		partial void OnSeasonIDChanging(System.Nullable<decimal> value);
		
		partial void OnTrailerChanged();
		
		partial void OnTrailerChanging(string value);
		
		partial void OnVOdChanged();
		
		partial void OnVOdChanging(System.Nullable<int> value);
		#endregion
		
		
		public MostRentedMovies()
		{
			this.OnCreated();
		}
		
		[Column(Storage="_broadcast", Name="broadcast", DbType="varchar(40)", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public string Broadcast
		{
			get
			{
				return this._broadcast;
			}
			set
			{
				if (((_broadcast == value) 
							== false))
				{
					this.OnBroadcastChanging(value);
					this._broadcast = value;
					this.OnBroadcastChanged();
				}
			}
		}
		
		[Column(Storage="_dcRp", Name="dcrp", DbType="text", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public string DcRp
		{
			get
			{
				return this._dcRp;
			}
			set
			{
				if (((_dcRp == value) 
							== false))
				{
					this.OnDcRpChanging(value);
					this._dcRp = value;
					this.OnDcRpChanged();
				}
			}
		}
		
		[Column(Storage="_diskID", Name="disk_id", DbType="int", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<int> DiskID
		{
			get
			{
				return this._diskID;
			}
			set
			{
				if ((_diskID != value))
				{
					this.OnDiskIDChanging(value);
					this._diskID = value;
					this.OnDiskIDChanged();
				}
			}
		}
		
		[Column(Storage="_imdBIdseRie", Name="imdb_id_serie", DbType="int unsigned", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<uint> IMDbIDSErie
		{
			get
			{
				return this._imdBIdseRie;
			}
			set
			{
				if ((_imdBIdseRie != value))
				{
					this.OnIMDbIDSErieChanging(value);
					this._imdBIdseRie = value;
					this.OnIMDbIDSErieChanged();
				}
			}
		}
		
		[Column(Storage="_imG", Name="img", DbType="varchar(500)", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public string IMg
		{
			get
			{
				return this._imG;
			}
			set
			{
				if (((_imG == value) 
							== false))
				{
					this.OnIMgChanging(value);
					this._imG = value;
					this.OnIMgChanged();
				}
			}
		}
		
		[Column(Storage="_lngID", Name="lngid", DbType="int", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<int> LNGiD
		{
			get
			{
				return this._lngID;
			}
			set
			{
				if ((_lngID != value))
				{
					this.OnLNGiDChanging(value);
					this._lngID = value;
					this.OnLNGiDChanged();
				}
			}
		}
		
		[Column(Storage="_name", Name="name", DbType="varchar(64)", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public string Name
		{
			get
			{
				return this._name;
			}
			set
			{
				if (((_name == value) 
							== false))
				{
					this.OnNameChanging(value);
					this._name = value;
					this.OnNameChanged();
				}
			}
		}
		
		[Column(Storage="_rate", Name="rate", DbType="decimal(2,1)", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<decimal> Rate
		{
			get
			{
				return this._rate;
			}
			set
			{
				if ((_rate != value))
				{
					this.OnRateChanging(value);
					this._rate = value;
					this.OnRateChanged();
				}
			}
		}
		
		[Column(Storage="_seasonID", Name="season_id", DbType="decimal(11,0)", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<decimal> SeasonID
		{
			get
			{
				return this._seasonID;
			}
			set
			{
				if ((_seasonID != value))
				{
					this.OnSeasonIDChanging(value);
					this._seasonID = value;
					this.OnSeasonIDChanged();
				}
			}
		}
		
		[Column(Storage="_trailer", Name="trailer", DbType="text", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public string Trailer
		{
			get
			{
				return this._trailer;
			}
			set
			{
				if (((_trailer == value) 
							== false))
				{
					this.OnTrailerChanging(value);
					this._trailer = value;
					this.OnTrailerChanged();
				}
			}
		}
		
		[Column(Storage="_voD", Name="vod", DbType="int", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<int> VOd
		{
			get
			{
				return this._voD;
			}
			set
			{
				if ((_voD != value))
				{
					this.OnVOdChanging(value);
					this._voD = value;
					this.OnVOdChanged();
				}
			}
		}
	}
	
	[Table(Name="plush_mobile.movie_dvd_products")]
	public partial class MovieDVdProducts
	{
		
		private System.Nullable<long> _diskID;
		
		private System.Nullable<uint> _imdBIdseRie;
		
		private string _languages;
		
		private int _productsID;
		
		private string _productsMedia;
		
		private System.Nullable<long> _seasonID;
		
		private string _subTitIlEs;
		
		#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnDiskIDChanged();
		
		partial void OnDiskIDChanging(System.Nullable<long> value);
		
		partial void OnIMDbIDSErieChanged();
		
		partial void OnIMDbIDSErieChanging(System.Nullable<uint> value);
		
		partial void OnLanguagesChanged();
		
		partial void OnLanguagesChanging(string value);
		
		partial void OnProductsIDChanged();
		
		partial void OnProductsIDChanging(int value);
		
		partial void OnProductsMediaChanged();
		
		partial void OnProductsMediaChanging(string value);
		
		partial void OnSeasonIDChanged();
		
		partial void OnSeasonIDChanging(System.Nullable<long> value);
		
		partial void OnSubTitIlEsChanged();
		
		partial void OnSubTitIlEsChanging(string value);
		#endregion
		
		
		public MovieDVdProducts()
		{
			this.OnCreated();
		}
		
		[Column(Storage="_diskID", Name="disk_id", DbType="bigint", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<long> DiskID
		{
			get
			{
				return this._diskID;
			}
			set
			{
				if ((_diskID != value))
				{
					this.OnDiskIDChanging(value);
					this._diskID = value;
					this.OnDiskIDChanged();
				}
			}
		}
		
		[Column(Storage="_imdBIdseRie", Name="imdb_id_serie", DbType="int unsigned", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<uint> IMDbIDSErie
		{
			get
			{
				return this._imdBIdseRie;
			}
			set
			{
				if ((_imdBIdseRie != value))
				{
					this.OnIMDbIDSErieChanging(value);
					this._imdBIdseRie = value;
					this.OnIMDbIDSErieChanged();
				}
			}
		}
		
		[Column(Storage="_languages", Name="languages", DbType="longtext", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public string Languages
		{
			get
			{
				return this._languages;
			}
			set
			{
				if (((_languages == value) 
							== false))
				{
					this.OnLanguagesChanging(value);
					this._languages = value;
					this.OnLanguagesChanged();
				}
			}
		}
		
		[Column(Storage="_productsID", Name="products_id", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int ProductsID
		{
			get
			{
				return this._productsID;
			}
			set
			{
				if ((_productsID != value))
				{
					this.OnProductsIDChanging(value);
					this._productsID = value;
					this.OnProductsIDChanged();
				}
			}
		}
		
		[Column(Storage="_productsMedia", Name="products_media", DbType="varchar(45)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string ProductsMedia
		{
			get
			{
				return this._productsMedia;
			}
			set
			{
				if (((_productsMedia == value) 
							== false))
				{
					this.OnProductsMediaChanging(value);
					this._productsMedia = value;
					this.OnProductsMediaChanged();
				}
			}
		}
		
		[Column(Storage="_seasonID", Name="season_id", DbType="bigint(12)", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<long> SeasonID
		{
			get
			{
				return this._seasonID;
			}
			set
			{
				if ((_seasonID != value))
				{
					this.OnSeasonIDChanging(value);
					this._seasonID = value;
					this.OnSeasonIDChanged();
				}
			}
		}
		
		[Column(Storage="_subTitIlEs", Name="subtitiles", DbType="longtext", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public string SubTitIlEs
		{
			get
			{
				return this._subTitIlEs;
			}
			set
			{
				if (((_subTitIlEs == value) 
							== false))
				{
					this.OnSubTitIlEsChanging(value);
					this._subTitIlEs = value;
					this.OnSubTitIlEsChanged();
				}
			}
		}
	}
	
	[Table(Name="plush_mobile.movies_rates")]
	public partial class MoviesRates : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	{
		
		private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");
		
		private int _imdBID;
		
		private System.Nullable<decimal> _rate;
		
		#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnIMDbIDChanged();
		
		partial void OnIMDbIDChanging(int value);
		
		partial void OnRateChanged();
		
		partial void OnRateChanging(System.Nullable<decimal> value);
		#endregion
		
		
		public MoviesRates()
		{
			this.OnCreated();
		}
		
		[Column(Storage="_imdBID", Name="imdb_id", DbType="int", IsPrimaryKey=true, AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int IMDbID
		{
			get
			{
				return this._imdBID;
			}
			set
			{
				if ((_imdBID != value))
				{
					this.OnIMDbIDChanging(value);
					this.SendPropertyChanging();
					this._imdBID = value;
					this.SendPropertyChanged("IMDbID");
					this.OnIMDbIDChanged();
				}
			}
		}
		
		[Column(Storage="_rate", Name="rate", DbType="decimal(3,2)", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<decimal> Rate
		{
			get
			{
				return this._rate;
			}
			set
			{
				if ((_rate != value))
				{
					this.OnRateChanging(value);
					this.SendPropertyChanging();
					this._rate = value;
					this.SendPropertyChanged("Rate");
					this.OnRateChanged();
				}
			}
		}
		
		public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
		
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
			if ((h != null))
			{
				h(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(string propertyName)
		{
			System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
			if ((h != null))
			{
				h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="plush_mobile.products__last_modified_ordered")]
	public partial class ProductsLastModifiedOrdered
	{
		
		private System.Nullable<int> _ciNEbELid;
		
		private System.Nullable<int> _ciNEbELtRailer;
		
		private int _crIteOsTatus;
		
		private System.Nullable<System.DateTime> _dateDisabled;
		
		private int _distributorsID;
		
		private int _feeSharing;
		
		private decimal _feeSharingBuyOptionPrice;
		
		private System.Nullable<System.DateTime> _feeSharingEnd;
		
		private int _feeSharingExpectedNbrtUrns;
		
		private decimal _feeSharingTurnPrice;
		
		private decimal _feeSharingTurnPriceAfter3mOnth;
		
		private decimal _feeSharingUpfrontFee;
		
		private int _feeSharingUpfrontFeeRecoverable;
		
		private string _gameConFigMini;
		
		private System.Nullable<uint> _gameNbroFPlayers;
		
		private System.Nullable<uint> _gameNbroFPlayersOnline;
		
		private System.Nullable<uint> _gameOnline;
		
		private uint _imdBID;
		
		private System.Nullable<uint> _imdBIdseRie;
		
		private int _inCinemaNow;
		
		private int _inTheBags;
		
		private int _inTheBagsNext;
		
		private System.Nullable<int> _manufacturersID;
		
		private int _onlyForSale;
		
		private int _productsAvailability;
		
		private int _productsBarCode;
		
		private int _productsCountriesID;
		
		private System.DateTime _productsDateAdded;
		
		private System.Nullable<System.DateTime> _productsDateAvailable;
		
		private int _productsDesire;
		
		private decimal _productsDesireWeighted;
		
		private System.Nullable<int> _productsDirectorsID;
		
		private int _productsDvDPostChoice;
		
		private int _productsDvDQuantity;
		
		private int _productsFrench;
		
		private int _productsID;
		
		private string _productsImage;
		
		private int _productsLanguageFr;
		
		private System.Nullable<System.DateTime> _productsLastModified;
		
		private string _productsMedia;
		
		private string _productsModel;
		
		private decimal _productsNewSalePrice;
		
		private int _productsNext;
		
		private int _productsOrdered;
		
		private System.Nullable<int> _productsOtherLanguage;
		
		private System.Nullable<int> _productsPictureFormat;
		
		private decimal _productsPrice;
		
		private string _productsProductType;
		
		private System.Nullable<int> _productsPublic;
		
		private int _productsQuantity;
		
		private System.Nullable<int> _productsRating;
		
		private System.Nullable<int> _productsRegionalCode;
		
		private System.Nullable<int> _productsRuntime;
		
		private System.Nullable<System.DateTime> _productsSaleDate;
		
		private decimal _productsSalePrice;
		
		private int _productsSeriesAboProcessID;
		
		private int _productsSeriesAboProcessNumber;
		
		private int _productsSeriesID;
		
		private int _productsSeriesNumber;
		
		private int _productsStatus;
		
		private System.Nullable<int> _productsStudio;
		
		private int _productsTaxClassID;
		
		private int _productsTisCaliHpFr;
		
		private int _productsTisCaliHpNl;
		
		private string _productsTitle;
		
		private string _productsType;
		
		private int _productsUnderTitleNl;
		
		private System.Nullable<int> _productsWeight;
		
		private System.Nullable<int> _productsYear;
		
		private int _quantityNewToSale;
		
		private int _quantityToSale;
		
		private uint _ratingCount;
		
		private uint _ratingUsers;
		
		#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnCInEBeLIDChanged();
		
		partial void OnCInEBeLIDChanging(System.Nullable<int> value);
		
		partial void OnCInEBeLTrailerChanged();
		
		partial void OnCInEBeLTrailerChanging(System.Nullable<int> value);
		
		partial void OnCRiteOStatusChanged();
		
		partial void OnCRiteOStatusChanging(int value);
		
		partial void OnDateDisabledChanged();
		
		partial void OnDateDisabledChanging(System.Nullable<System.DateTime> value);
		
		partial void OnDistributorsIDChanged();
		
		partial void OnDistributorsIDChanging(int value);
		
		partial void OnFeeSharingChanged();
		
		partial void OnFeeSharingChanging(int value);
		
		partial void OnFeeSharingBuyOptionPriceChanged();
		
		partial void OnFeeSharingBuyOptionPriceChanging(decimal value);
		
		partial void OnFeeSharingEndChanged();
		
		partial void OnFeeSharingEndChanging(System.Nullable<System.DateTime> value);
		
		partial void OnFeeSharingExpectedNBRTurnsChanged();
		
		partial void OnFeeSharingExpectedNBRTurnsChanging(int value);
		
		partial void OnFeeSharingTurnPriceChanged();
		
		partial void OnFeeSharingTurnPriceChanging(decimal value);
		
		partial void OnFeeSharingTurnPriceAfter3MonthChanged();
		
		partial void OnFeeSharingTurnPriceAfter3MonthChanging(decimal value);
		
		partial void OnFeeSharingUpfrontFeeChanged();
		
		partial void OnFeeSharingUpfrontFeeChanging(decimal value);
		
		partial void OnFeeSharingUpfrontFeeRecoverableChanged();
		
		partial void OnFeeSharingUpfrontFeeRecoverableChanging(int value);
		
		partial void OnGameConFigMiniChanged();
		
		partial void OnGameConFigMiniChanging(string value);
		
		partial void OnGameNBROfPlayersChanged();
		
		partial void OnGameNBROfPlayersChanging(System.Nullable<uint> value);
		
		partial void OnGameNBROfPlayersOnlineChanged();
		
		partial void OnGameNBROfPlayersOnlineChanging(System.Nullable<uint> value);
		
		partial void OnGameOnlineChanged();
		
		partial void OnGameOnlineChanging(System.Nullable<uint> value);
		
		partial void OnIMDbIDChanged();
		
		partial void OnIMDbIDChanging(uint value);
		
		partial void OnIMDbIDSErieChanged();
		
		partial void OnIMDbIDSErieChanging(System.Nullable<uint> value);
		
		partial void OnInCinemaNowChanged();
		
		partial void OnInCinemaNowChanging(int value);
		
		partial void OnInTheBagsChanged();
		
		partial void OnInTheBagsChanging(int value);
		
		partial void OnInTheBagsNextChanged();
		
		partial void OnInTheBagsNextChanging(int value);
		
		partial void OnManufacturersIDChanged();
		
		partial void OnManufacturersIDChanging(System.Nullable<int> value);
		
		partial void OnOnlyForSaleChanged();
		
		partial void OnOnlyForSaleChanging(int value);
		
		partial void OnProductsAvailabilityChanged();
		
		partial void OnProductsAvailabilityChanging(int value);
		
		partial void OnProductsBarCodeChanged();
		
		partial void OnProductsBarCodeChanging(int value);
		
		partial void OnProductsCountriesIDChanged();
		
		partial void OnProductsCountriesIDChanging(int value);
		
		partial void OnProductsDateAddedChanged();
		
		partial void OnProductsDateAddedChanging(System.DateTime value);
		
		partial void OnProductsDateAvailableChanged();
		
		partial void OnProductsDateAvailableChanging(System.Nullable<System.DateTime> value);
		
		partial void OnProductsDesireChanged();
		
		partial void OnProductsDesireChanging(int value);
		
		partial void OnProductsDesireWeightedChanged();
		
		partial void OnProductsDesireWeightedChanging(decimal value);
		
		partial void OnProductsDirectorsIDChanged();
		
		partial void OnProductsDirectorsIDChanging(System.Nullable<int> value);
		
		partial void OnProductsDVdPostChoiceChanged();
		
		partial void OnProductsDVdPostChoiceChanging(int value);
		
		partial void OnProductsDVdQuantityChanged();
		
		partial void OnProductsDVdQuantityChanging(int value);
		
		partial void OnProductsFrenchChanged();
		
		partial void OnProductsFrenchChanging(int value);
		
		partial void OnProductsIDChanged();
		
		partial void OnProductsIDChanging(int value);
		
		partial void OnProductsImageChanged();
		
		partial void OnProductsImageChanging(string value);
		
		partial void OnProductsLanguageFrChanged();
		
		partial void OnProductsLanguageFrChanging(int value);
		
		partial void OnProductsLastModifiedChanged();
		
		partial void OnProductsLastModifiedChanging(System.Nullable<System.DateTime> value);
		
		partial void OnProductsMediaChanged();
		
		partial void OnProductsMediaChanging(string value);
		
		partial void OnProductsModelChanged();
		
		partial void OnProductsModelChanging(string value);
		
		partial void OnProductsNewSalePriceChanged();
		
		partial void OnProductsNewSalePriceChanging(decimal value);
		
		partial void OnProductsNextChanged();
		
		partial void OnProductsNextChanging(int value);
		
		partial void OnProductsOrderedChanged();
		
		partial void OnProductsOrderedChanging(int value);
		
		partial void OnProductsOtherLanguageChanged();
		
		partial void OnProductsOtherLanguageChanging(System.Nullable<int> value);
		
		partial void OnProductsPictureFormatChanged();
		
		partial void OnProductsPictureFormatChanging(System.Nullable<int> value);
		
		partial void OnProductsPriceChanged();
		
		partial void OnProductsPriceChanging(decimal value);
		
		partial void OnProductsProductTypeChanged();
		
		partial void OnProductsProductTypeChanging(string value);
		
		partial void OnProductsPublicChanged();
		
		partial void OnProductsPublicChanging(System.Nullable<int> value);
		
		partial void OnProductsQuantityChanged();
		
		partial void OnProductsQuantityChanging(int value);
		
		partial void OnProductsRatingChanged();
		
		partial void OnProductsRatingChanging(System.Nullable<int> value);
		
		partial void OnProductsRegionalCodeChanged();
		
		partial void OnProductsRegionalCodeChanging(System.Nullable<int> value);
		
		partial void OnProductsRuntimeChanged();
		
		partial void OnProductsRuntimeChanging(System.Nullable<int> value);
		
		partial void OnProductsSaleDateChanged();
		
		partial void OnProductsSaleDateChanging(System.Nullable<System.DateTime> value);
		
		partial void OnProductsSalePriceChanged();
		
		partial void OnProductsSalePriceChanging(decimal value);
		
		partial void OnProductsSeriesAboProcessIDChanged();
		
		partial void OnProductsSeriesAboProcessIDChanging(int value);
		
		partial void OnProductsSeriesAboProcessNumberChanged();
		
		partial void OnProductsSeriesAboProcessNumberChanging(int value);
		
		partial void OnProductsSeriesIDChanged();
		
		partial void OnProductsSeriesIDChanging(int value);
		
		partial void OnProductsSeriesNumberChanged();
		
		partial void OnProductsSeriesNumberChanging(int value);
		
		partial void OnProductsStatusChanged();
		
		partial void OnProductsStatusChanging(int value);
		
		partial void OnProductsStudioChanged();
		
		partial void OnProductsStudioChanging(System.Nullable<int> value);
		
		partial void OnProductsTaxClassIDChanged();
		
		partial void OnProductsTaxClassIDChanging(int value);
		
		partial void OnProductsTisCaliHpFrChanged();
		
		partial void OnProductsTisCaliHpFrChanging(int value);
		
		partial void OnProductsTisCaliHpNLChanged();
		
		partial void OnProductsTisCaliHpNLChanging(int value);
		
		partial void OnProductsTitleChanged();
		
		partial void OnProductsTitleChanging(string value);
		
		partial void OnProductsTypeChanged();
		
		partial void OnProductsTypeChanging(string value);
		
		partial void OnProductsUnderTitleNLChanged();
		
		partial void OnProductsUnderTitleNLChanging(int value);
		
		partial void OnProductsWeightChanged();
		
		partial void OnProductsWeightChanging(System.Nullable<int> value);
		
		partial void OnProductsYearChanged();
		
		partial void OnProductsYearChanging(System.Nullable<int> value);
		
		partial void OnQuantityNewToSaleChanged();
		
		partial void OnQuantityNewToSaleChanging(int value);
		
		partial void OnQuantityToSaleChanged();
		
		partial void OnQuantityToSaleChanging(int value);
		
		partial void OnRatingCountChanged();
		
		partial void OnRatingCountChanging(uint value);
		
		partial void OnRatingUsersChanged();
		
		partial void OnRatingUsersChanging(uint value);
		#endregion
		
		
		public ProductsLastModifiedOrdered()
		{
			this.OnCreated();
		}
		
		[Column(Storage="_ciNEbELid", Name="cinebel_id", DbType="int", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<int> CInEBeLID
		{
			get
			{
				return this._ciNEbELid;
			}
			set
			{
				if ((_ciNEbELid != value))
				{
					this.OnCInEBeLIDChanging(value);
					this._ciNEbELid = value;
					this.OnCInEBeLIDChanged();
				}
			}
		}
		
		[Column(Storage="_ciNEbELtRailer", Name="cinebel_trailer", DbType="int", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<int> CInEBeLTrailer
		{
			get
			{
				return this._ciNEbELtRailer;
			}
			set
			{
				if ((_ciNEbELtRailer != value))
				{
					this.OnCInEBeLTrailerChanging(value);
					this._ciNEbELtRailer = value;
					this.OnCInEBeLTrailerChanged();
				}
			}
		}
		
		[Column(Storage="_crIteOsTatus", Name="criteo_status", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int CRiteOStatus
		{
			get
			{
				return this._crIteOsTatus;
			}
			set
			{
				if ((_crIteOsTatus != value))
				{
					this.OnCRiteOStatusChanging(value);
					this._crIteOsTatus = value;
					this.OnCRiteOStatusChanged();
				}
			}
		}
		
		[Column(Storage="_dateDisabled", Name="date_disabled", DbType="datetime", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<System.DateTime> DateDisabled
		{
			get
			{
				return this._dateDisabled;
			}
			set
			{
				if ((_dateDisabled != value))
				{
					this.OnDateDisabledChanging(value);
					this._dateDisabled = value;
					this.OnDateDisabledChanged();
				}
			}
		}
		
		[Column(Storage="_distributorsID", Name="distributors_id", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int DistributorsID
		{
			get
			{
				return this._distributorsID;
			}
			set
			{
				if ((_distributorsID != value))
				{
					this.OnDistributorsIDChanging(value);
					this._distributorsID = value;
					this.OnDistributorsIDChanged();
				}
			}
		}
		
		[Column(Storage="_feeSharing", Name="feesharing", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int FeeSharing
		{
			get
			{
				return this._feeSharing;
			}
			set
			{
				if ((_feeSharing != value))
				{
					this.OnFeeSharingChanging(value);
					this._feeSharing = value;
					this.OnFeeSharingChanged();
				}
			}
		}
		
		[Column(Storage="_feeSharingBuyOptionPrice", Name="feesharing_buy_option_price", DbType="decimal(4,2)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public decimal FeeSharingBuyOptionPrice
		{
			get
			{
				return this._feeSharingBuyOptionPrice;
			}
			set
			{
				if ((_feeSharingBuyOptionPrice != value))
				{
					this.OnFeeSharingBuyOptionPriceChanging(value);
					this._feeSharingBuyOptionPrice = value;
					this.OnFeeSharingBuyOptionPriceChanged();
				}
			}
		}
		
		[Column(Storage="_feeSharingEnd", Name="feesharing_end", DbType="date", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<System.DateTime> FeeSharingEnd
		{
			get
			{
				return this._feeSharingEnd;
			}
			set
			{
				if ((_feeSharingEnd != value))
				{
					this.OnFeeSharingEndChanging(value);
					this._feeSharingEnd = value;
					this.OnFeeSharingEndChanged();
				}
			}
		}
		
		[Column(Storage="_feeSharingExpectedNbrtUrns", Name="feesharing_expected_nbr_turns", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int FeeSharingExpectedNBRTurns
		{
			get
			{
				return this._feeSharingExpectedNbrtUrns;
			}
			set
			{
				if ((_feeSharingExpectedNbrtUrns != value))
				{
					this.OnFeeSharingExpectedNBRTurnsChanging(value);
					this._feeSharingExpectedNbrtUrns = value;
					this.OnFeeSharingExpectedNBRTurnsChanged();
				}
			}
		}
		
		[Column(Storage="_feeSharingTurnPrice", Name="feesharing_turn_price", DbType="decimal(4,2)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public decimal FeeSharingTurnPrice
		{
			get
			{
				return this._feeSharingTurnPrice;
			}
			set
			{
				if ((_feeSharingTurnPrice != value))
				{
					this.OnFeeSharingTurnPriceChanging(value);
					this._feeSharingTurnPrice = value;
					this.OnFeeSharingTurnPriceChanged();
				}
			}
		}
		
		[Column(Storage="_feeSharingTurnPriceAfter3mOnth", Name="feesharing_turn_price_after3month", DbType="decimal(4,2)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public decimal FeeSharingTurnPriceAfter3Month
		{
			get
			{
				return this._feeSharingTurnPriceAfter3mOnth;
			}
			set
			{
				if ((_feeSharingTurnPriceAfter3mOnth != value))
				{
					this.OnFeeSharingTurnPriceAfter3MonthChanging(value);
					this._feeSharingTurnPriceAfter3mOnth = value;
					this.OnFeeSharingTurnPriceAfter3MonthChanged();
				}
			}
		}
		
		[Column(Storage="_feeSharingUpfrontFee", Name="feesharing_upfront_fee", DbType="decimal(4,2)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public decimal FeeSharingUpfrontFee
		{
			get
			{
				return this._feeSharingUpfrontFee;
			}
			set
			{
				if ((_feeSharingUpfrontFee != value))
				{
					this.OnFeeSharingUpfrontFeeChanging(value);
					this._feeSharingUpfrontFee = value;
					this.OnFeeSharingUpfrontFeeChanged();
				}
			}
		}
		
		[Column(Storage="_feeSharingUpfrontFeeRecoverable", Name="feesharing_upfront_fee_recoverable", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int FeeSharingUpfrontFeeRecoverable
		{
			get
			{
				return this._feeSharingUpfrontFeeRecoverable;
			}
			set
			{
				if ((_feeSharingUpfrontFeeRecoverable != value))
				{
					this.OnFeeSharingUpfrontFeeRecoverableChanging(value);
					this._feeSharingUpfrontFeeRecoverable = value;
					this.OnFeeSharingUpfrontFeeRecoverableChanged();
				}
			}
		}
		
		[Column(Storage="_gameConFigMini", Name="game_config_mini", DbType="varchar(250)", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public string GameConFigMini
		{
			get
			{
				return this._gameConFigMini;
			}
			set
			{
				if (((_gameConFigMini == value) 
							== false))
				{
					this.OnGameConFigMiniChanging(value);
					this._gameConFigMini = value;
					this.OnGameConFigMiniChanged();
				}
			}
		}
		
		[Column(Storage="_gameNbroFPlayers", Name="game_nbr_of_players", DbType="int unsigned", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<uint> GameNBROfPlayers
		{
			get
			{
				return this._gameNbroFPlayers;
			}
			set
			{
				if ((_gameNbroFPlayers != value))
				{
					this.OnGameNBROfPlayersChanging(value);
					this._gameNbroFPlayers = value;
					this.OnGameNBROfPlayersChanged();
				}
			}
		}
		
		[Column(Storage="_gameNbroFPlayersOnline", Name="game_nbr_of_players_online", DbType="int unsigned", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<uint> GameNBROfPlayersOnline
		{
			get
			{
				return this._gameNbroFPlayersOnline;
			}
			set
			{
				if ((_gameNbroFPlayersOnline != value))
				{
					this.OnGameNBROfPlayersOnlineChanging(value);
					this._gameNbroFPlayersOnline = value;
					this.OnGameNBROfPlayersOnlineChanged();
				}
			}
		}
		
		[Column(Storage="_gameOnline", Name="game_online", DbType="int unsigned", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<uint> GameOnline
		{
			get
			{
				return this._gameOnline;
			}
			set
			{
				if ((_gameOnline != value))
				{
					this.OnGameOnlineChanging(value);
					this._gameOnline = value;
					this.OnGameOnlineChanged();
				}
			}
		}
		
		[Column(Storage="_imdBID", Name="imdb_id", DbType="int unsigned", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public uint IMDbID
		{
			get
			{
				return this._imdBID;
			}
			set
			{
				if ((_imdBID != value))
				{
					this.OnIMDbIDChanging(value);
					this._imdBID = value;
					this.OnIMDbIDChanged();
				}
			}
		}
		
		[Column(Storage="_imdBIdseRie", Name="imdb_id_serie", DbType="int unsigned", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<uint> IMDbIDSErie
		{
			get
			{
				return this._imdBIdseRie;
			}
			set
			{
				if ((_imdBIdseRie != value))
				{
					this.OnIMDbIDSErieChanging(value);
					this._imdBIdseRie = value;
					this.OnIMDbIDSErieChanged();
				}
			}
		}
		
		[Column(Storage="_inCinemaNow", Name="in_cinema_now", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int InCinemaNow
		{
			get
			{
				return this._inCinemaNow;
			}
			set
			{
				if ((_inCinemaNow != value))
				{
					this.OnInCinemaNowChanging(value);
					this._inCinemaNow = value;
					this.OnInCinemaNowChanged();
				}
			}
		}
		
		[Column(Storage="_inTheBags", Name="in_the_bags", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int InTheBags
		{
			get
			{
				return this._inTheBags;
			}
			set
			{
				if ((_inTheBags != value))
				{
					this.OnInTheBagsChanging(value);
					this._inTheBags = value;
					this.OnInTheBagsChanged();
				}
			}
		}
		
		[Column(Storage="_inTheBagsNext", Name="in_the_bags_next", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int InTheBagsNext
		{
			get
			{
				return this._inTheBagsNext;
			}
			set
			{
				if ((_inTheBagsNext != value))
				{
					this.OnInTheBagsNextChanging(value);
					this._inTheBagsNext = value;
					this.OnInTheBagsNextChanged();
				}
			}
		}
		
		[Column(Storage="_manufacturersID", Name="manufacturers_id", DbType="int", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<int> ManufacturersID
		{
			get
			{
				return this._manufacturersID;
			}
			set
			{
				if ((_manufacturersID != value))
				{
					this.OnManufacturersIDChanging(value);
					this._manufacturersID = value;
					this.OnManufacturersIDChanged();
				}
			}
		}
		
		[Column(Storage="_onlyForSale", Name="only_for_sale", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int OnlyForSale
		{
			get
			{
				return this._onlyForSale;
			}
			set
			{
				if ((_onlyForSale != value))
				{
					this.OnOnlyForSaleChanging(value);
					this._onlyForSale = value;
					this.OnOnlyForSaleChanged();
				}
			}
		}
		
		[Column(Storage="_productsAvailability", Name="products_availability", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int ProductsAvailability
		{
			get
			{
				return this._productsAvailability;
			}
			set
			{
				if ((_productsAvailability != value))
				{
					this.OnProductsAvailabilityChanging(value);
					this._productsAvailability = value;
					this.OnProductsAvailabilityChanged();
				}
			}
		}
		
		[Column(Storage="_productsBarCode", Name="products_barcode", DbType="int(13)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int ProductsBarCode
		{
			get
			{
				return this._productsBarCode;
			}
			set
			{
				if ((_productsBarCode != value))
				{
					this.OnProductsBarCodeChanging(value);
					this._productsBarCode = value;
					this.OnProductsBarCodeChanged();
				}
			}
		}
		
		[Column(Storage="_productsCountriesID", Name="products_countries_id", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int ProductsCountriesID
		{
			get
			{
				return this._productsCountriesID;
			}
			set
			{
				if ((_productsCountriesID != value))
				{
					this.OnProductsCountriesIDChanging(value);
					this._productsCountriesID = value;
					this.OnProductsCountriesIDChanged();
				}
			}
		}
		
		[Column(Storage="_productsDateAdded", Name="products_date_added", DbType="datetime", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public System.DateTime ProductsDateAdded
		{
			get
			{
				return this._productsDateAdded;
			}
			set
			{
				if ((_productsDateAdded != value))
				{
					this.OnProductsDateAddedChanging(value);
					this._productsDateAdded = value;
					this.OnProductsDateAddedChanged();
				}
			}
		}
		
		[Column(Storage="_productsDateAvailable", Name="products_date_available", DbType="datetime", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<System.DateTime> ProductsDateAvailable
		{
			get
			{
				return this._productsDateAvailable;
			}
			set
			{
				if ((_productsDateAvailable != value))
				{
					this.OnProductsDateAvailableChanging(value);
					this._productsDateAvailable = value;
					this.OnProductsDateAvailableChanged();
				}
			}
		}
		
		[Column(Storage="_productsDesire", Name="products_desire", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int ProductsDesire
		{
			get
			{
				return this._productsDesire;
			}
			set
			{
				if ((_productsDesire != value))
				{
					this.OnProductsDesireChanging(value);
					this._productsDesire = value;
					this.OnProductsDesireChanged();
				}
			}
		}
		
		[Column(Storage="_productsDesireWeighted", Name="products_desire_weighted", DbType="decimal(15,2)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public decimal ProductsDesireWeighted
		{
			get
			{
				return this._productsDesireWeighted;
			}
			set
			{
				if ((_productsDesireWeighted != value))
				{
					this.OnProductsDesireWeightedChanging(value);
					this._productsDesireWeighted = value;
					this.OnProductsDesireWeightedChanged();
				}
			}
		}
		
		[Column(Storage="_productsDirectorsID", Name="products_directors_id", DbType="int", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<int> ProductsDirectorsID
		{
			get
			{
				return this._productsDirectorsID;
			}
			set
			{
				if ((_productsDirectorsID != value))
				{
					this.OnProductsDirectorsIDChanging(value);
					this._productsDirectorsID = value;
					this.OnProductsDirectorsIDChanged();
				}
			}
		}
		
		[Column(Storage="_productsDvDPostChoice", Name="products_dvdpostchoice", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int ProductsDVdPostChoice
		{
			get
			{
				return this._productsDvDPostChoice;
			}
			set
			{
				if ((_productsDvDPostChoice != value))
				{
					this.OnProductsDVdPostChoiceChanging(value);
					this._productsDvDPostChoice = value;
					this.OnProductsDVdPostChoiceChanged();
				}
			}
		}
		
		[Column(Storage="_productsDvDQuantity", Name="products_dvd_quantity", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int ProductsDVdQuantity
		{
			get
			{
				return this._productsDvDQuantity;
			}
			set
			{
				if ((_productsDvDQuantity != value))
				{
					this.OnProductsDVdQuantityChanging(value);
					this._productsDvDQuantity = value;
					this.OnProductsDVdQuantityChanged();
				}
			}
		}
		
		[Column(Storage="_productsFrench", Name="products_french", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int ProductsFrench
		{
			get
			{
				return this._productsFrench;
			}
			set
			{
				if ((_productsFrench != value))
				{
					this.OnProductsFrenchChanging(value);
					this._productsFrench = value;
					this.OnProductsFrenchChanged();
				}
			}
		}
		
		[Column(Storage="_productsID", Name="products_id", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int ProductsID
		{
			get
			{
				return this._productsID;
			}
			set
			{
				if ((_productsID != value))
				{
					this.OnProductsIDChanging(value);
					this._productsID = value;
					this.OnProductsIDChanged();
				}
			}
		}
		
		[Column(Storage="_productsImage", Name="products_image", DbType="varchar(64)", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public string ProductsImage
		{
			get
			{
				return this._productsImage;
			}
			set
			{
				if (((_productsImage == value) 
							== false))
				{
					this.OnProductsImageChanging(value);
					this._productsImage = value;
					this.OnProductsImageChanged();
				}
			}
		}
		
		[Column(Storage="_productsLanguageFr", Name="products_language_fr", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int ProductsLanguageFr
		{
			get
			{
				return this._productsLanguageFr;
			}
			set
			{
				if ((_productsLanguageFr != value))
				{
					this.OnProductsLanguageFrChanging(value);
					this._productsLanguageFr = value;
					this.OnProductsLanguageFrChanged();
				}
			}
		}
		
		[Column(Storage="_productsLastModified", Name="products_last_modified", DbType="datetime", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<System.DateTime> ProductsLastModified
		{
			get
			{
				return this._productsLastModified;
			}
			set
			{
				if ((_productsLastModified != value))
				{
					this.OnProductsLastModifiedChanging(value);
					this._productsLastModified = value;
					this.OnProductsLastModifiedChanged();
				}
			}
		}
		
		[Column(Storage="_productsMedia", Name="products_media", DbType="varchar(45)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string ProductsMedia
		{
			get
			{
				return this._productsMedia;
			}
			set
			{
				if (((_productsMedia == value) 
							== false))
				{
					this.OnProductsMediaChanging(value);
					this._productsMedia = value;
					this.OnProductsMediaChanged();
				}
			}
		}
		
		[Column(Storage="_productsModel", Name="products_model", DbType="varchar(50)", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public string ProductsModel
		{
			get
			{
				return this._productsModel;
			}
			set
			{
				if (((_productsModel == value) 
							== false))
				{
					this.OnProductsModelChanging(value);
					this._productsModel = value;
					this.OnProductsModelChanged();
				}
			}
		}
		
		[Column(Storage="_productsNewSalePrice", Name="products_new_sale_price", DbType="decimal(5,2)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public decimal ProductsNewSalePrice
		{
			get
			{
				return this._productsNewSalePrice;
			}
			set
			{
				if ((_productsNewSalePrice != value))
				{
					this.OnProductsNewSalePriceChanging(value);
					this._productsNewSalePrice = value;
					this.OnProductsNewSalePriceChanged();
				}
			}
		}
		
		[Column(Storage="_productsNext", Name="products_next", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int ProductsNext
		{
			get
			{
				return this._productsNext;
			}
			set
			{
				if ((_productsNext != value))
				{
					this.OnProductsNextChanging(value);
					this._productsNext = value;
					this.OnProductsNextChanged();
				}
			}
		}
		
		[Column(Storage="_productsOrdered", Name="products_ordered", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int ProductsOrdered
		{
			get
			{
				return this._productsOrdered;
			}
			set
			{
				if ((_productsOrdered != value))
				{
					this.OnProductsOrderedChanging(value);
					this._productsOrdered = value;
					this.OnProductsOrderedChanged();
				}
			}
		}
		
		[Column(Storage="_productsOtherLanguage", Name="products_other_language", DbType="int", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<int> ProductsOtherLanguage
		{
			get
			{
				return this._productsOtherLanguage;
			}
			set
			{
				if ((_productsOtherLanguage != value))
				{
					this.OnProductsOtherLanguageChanging(value);
					this._productsOtherLanguage = value;
					this.OnProductsOtherLanguageChanged();
				}
			}
		}
		
		[Column(Storage="_productsPictureFormat", Name="products_picture_format", DbType="int", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<int> ProductsPictureFormat
		{
			get
			{
				return this._productsPictureFormat;
			}
			set
			{
				if ((_productsPictureFormat != value))
				{
					this.OnProductsPictureFormatChanging(value);
					this._productsPictureFormat = value;
					this.OnProductsPictureFormatChanged();
				}
			}
		}
		
		[Column(Storage="_productsPrice", Name="products_price", DbType="decimal(5,2)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public decimal ProductsPrice
		{
			get
			{
				return this._productsPrice;
			}
			set
			{
				if ((_productsPrice != value))
				{
					this.OnProductsPriceChanging(value);
					this._productsPrice = value;
					this.OnProductsPriceChanged();
				}
			}
		}
		
		[Column(Storage="_productsProductType", Name="products_product_type", DbType="varchar(45)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string ProductsProductType
		{
			get
			{
				return this._productsProductType;
			}
			set
			{
				if (((_productsProductType == value) 
							== false))
				{
					this.OnProductsProductTypeChanging(value);
					this._productsProductType = value;
					this.OnProductsProductTypeChanged();
				}
			}
		}
		
		[Column(Storage="_productsPublic", Name="products_public", DbType="int", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<int> ProductsPublic
		{
			get
			{
				return this._productsPublic;
			}
			set
			{
				if ((_productsPublic != value))
				{
					this.OnProductsPublicChanging(value);
					this._productsPublic = value;
					this.OnProductsPublicChanged();
				}
			}
		}
		
		[Column(Storage="_productsQuantity", Name="products_quantity", DbType="int(4)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int ProductsQuantity
		{
			get
			{
				return this._productsQuantity;
			}
			set
			{
				if ((_productsQuantity != value))
				{
					this.OnProductsQuantityChanging(value);
					this._productsQuantity = value;
					this.OnProductsQuantityChanged();
				}
			}
		}
		
		[Column(Storage="_productsRating", Name="products_rating", DbType="int", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<int> ProductsRating
		{
			get
			{
				return this._productsRating;
			}
			set
			{
				if ((_productsRating != value))
				{
					this.OnProductsRatingChanging(value);
					this._productsRating = value;
					this.OnProductsRatingChanged();
				}
			}
		}
		
		[Column(Storage="_productsRegionalCode", Name="products_regional_code", DbType="int", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<int> ProductsRegionalCode
		{
			get
			{
				return this._productsRegionalCode;
			}
			set
			{
				if ((_productsRegionalCode != value))
				{
					this.OnProductsRegionalCodeChanging(value);
					this._productsRegionalCode = value;
					this.OnProductsRegionalCodeChanged();
				}
			}
		}
		
		[Column(Storage="_productsRuntime", Name="products_runtime", DbType="int", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<int> ProductsRuntime
		{
			get
			{
				return this._productsRuntime;
			}
			set
			{
				if ((_productsRuntime != value))
				{
					this.OnProductsRuntimeChanging(value);
					this._productsRuntime = value;
					this.OnProductsRuntimeChanged();
				}
			}
		}
		
		[Column(Storage="_productsSaleDate", Name="products_sale_date", DbType="datetime", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<System.DateTime> ProductsSaleDate
		{
			get
			{
				return this._productsSaleDate;
			}
			set
			{
				if ((_productsSaleDate != value))
				{
					this.OnProductsSaleDateChanging(value);
					this._productsSaleDate = value;
					this.OnProductsSaleDateChanged();
				}
			}
		}
		
		[Column(Storage="_productsSalePrice", Name="products_sale_price", DbType="decimal(5,2)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public decimal ProductsSalePrice
		{
			get
			{
				return this._productsSalePrice;
			}
			set
			{
				if ((_productsSalePrice != value))
				{
					this.OnProductsSalePriceChanging(value);
					this._productsSalePrice = value;
					this.OnProductsSalePriceChanged();
				}
			}
		}
		
		[Column(Storage="_productsSeriesAboProcessID", Name="products_series_aboprocess_id", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int ProductsSeriesAboProcessID
		{
			get
			{
				return this._productsSeriesAboProcessID;
			}
			set
			{
				if ((_productsSeriesAboProcessID != value))
				{
					this.OnProductsSeriesAboProcessIDChanging(value);
					this._productsSeriesAboProcessID = value;
					this.OnProductsSeriesAboProcessIDChanged();
				}
			}
		}
		
		[Column(Storage="_productsSeriesAboProcessNumber", Name="products_series_aboprocess_number", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int ProductsSeriesAboProcessNumber
		{
			get
			{
				return this._productsSeriesAboProcessNumber;
			}
			set
			{
				if ((_productsSeriesAboProcessNumber != value))
				{
					this.OnProductsSeriesAboProcessNumberChanging(value);
					this._productsSeriesAboProcessNumber = value;
					this.OnProductsSeriesAboProcessNumberChanged();
				}
			}
		}
		
		[Column(Storage="_productsSeriesID", Name="products_series_id", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int ProductsSeriesID
		{
			get
			{
				return this._productsSeriesID;
			}
			set
			{
				if ((_productsSeriesID != value))
				{
					this.OnProductsSeriesIDChanging(value);
					this._productsSeriesID = value;
					this.OnProductsSeriesIDChanged();
				}
			}
		}
		
		[Column(Storage="_productsSeriesNumber", Name="products_series_number", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int ProductsSeriesNumber
		{
			get
			{
				return this._productsSeriesNumber;
			}
			set
			{
				if ((_productsSeriesNumber != value))
				{
					this.OnProductsSeriesNumberChanging(value);
					this._productsSeriesNumber = value;
					this.OnProductsSeriesNumberChanged();
				}
			}
		}
		
		[Column(Storage="_productsStatus", Name="products_status", DbType="int(1)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int ProductsStatus
		{
			get
			{
				return this._productsStatus;
			}
			set
			{
				if ((_productsStatus != value))
				{
					this.OnProductsStatusChanging(value);
					this._productsStatus = value;
					this.OnProductsStatusChanged();
				}
			}
		}
		
		[Column(Storage="_productsStudio", Name="products_studio", DbType="int", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<int> ProductsStudio
		{
			get
			{
				return this._productsStudio;
			}
			set
			{
				if ((_productsStudio != value))
				{
					this.OnProductsStudioChanging(value);
					this._productsStudio = value;
					this.OnProductsStudioChanged();
				}
			}
		}
		
		[Column(Storage="_productsTaxClassID", Name="products_tax_class_id", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int ProductsTaxClassID
		{
			get
			{
				return this._productsTaxClassID;
			}
			set
			{
				if ((_productsTaxClassID != value))
				{
					this.OnProductsTaxClassIDChanging(value);
					this._productsTaxClassID = value;
					this.OnProductsTaxClassIDChanged();
				}
			}
		}
		
		[Column(Storage="_productsTisCaliHpFr", Name="products_tiscali_hp_fr", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int ProductsTisCaliHpFr
		{
			get
			{
				return this._productsTisCaliHpFr;
			}
			set
			{
				if ((_productsTisCaliHpFr != value))
				{
					this.OnProductsTisCaliHpFrChanging(value);
					this._productsTisCaliHpFr = value;
					this.OnProductsTisCaliHpFrChanged();
				}
			}
		}
		
		[Column(Storage="_productsTisCaliHpNl", Name="products_tiscali_hp_nl", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int ProductsTisCaliHpNL
		{
			get
			{
				return this._productsTisCaliHpNl;
			}
			set
			{
				if ((_productsTisCaliHpNl != value))
				{
					this.OnProductsTisCaliHpNLChanging(value);
					this._productsTisCaliHpNl = value;
					this.OnProductsTisCaliHpNLChanged();
				}
			}
		}
		
		[Column(Storage="_productsTitle", Name="products_title", DbType="varchar(255)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string ProductsTitle
		{
			get
			{
				return this._productsTitle;
			}
			set
			{
				if (((_productsTitle == value) 
							== false))
				{
					this.OnProductsTitleChanging(value);
					this._productsTitle = value;
					this.OnProductsTitleChanged();
				}
			}
		}
		
		[Column(Storage="_productsType", Name="products_type", DbType="varchar(10)", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public string ProductsType
		{
			get
			{
				return this._productsType;
			}
			set
			{
				if (((_productsType == value) 
							== false))
				{
					this.OnProductsTypeChanging(value);
					this._productsType = value;
					this.OnProductsTypeChanged();
				}
			}
		}
		
		[Column(Storage="_productsUnderTitleNl", Name="products_undertitle_nl", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int ProductsUnderTitleNL
		{
			get
			{
				return this._productsUnderTitleNl;
			}
			set
			{
				if ((_productsUnderTitleNl != value))
				{
					this.OnProductsUnderTitleNLChanging(value);
					this._productsUnderTitleNl = value;
					this.OnProductsUnderTitleNLChanged();
				}
			}
		}
		
		[Column(Storage="_productsWeight", Name="products_weight", DbType="int", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<int> ProductsWeight
		{
			get
			{
				return this._productsWeight;
			}
			set
			{
				if ((_productsWeight != value))
				{
					this.OnProductsWeightChanging(value);
					this._productsWeight = value;
					this.OnProductsWeightChanged();
				}
			}
		}
		
		[Column(Storage="_productsYear", Name="products_year", DbType="int", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public System.Nullable<int> ProductsYear
		{
			get
			{
				return this._productsYear;
			}
			set
			{
				if ((_productsYear != value))
				{
					this.OnProductsYearChanging(value);
					this._productsYear = value;
					this.OnProductsYearChanged();
				}
			}
		}
		
		[Column(Storage="_quantityNewToSale", Name="quantity_new_to_sale", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int QuantityNewToSale
		{
			get
			{
				return this._quantityNewToSale;
			}
			set
			{
				if ((_quantityNewToSale != value))
				{
					this.OnQuantityNewToSaleChanging(value);
					this._quantityNewToSale = value;
					this.OnQuantityNewToSaleChanged();
				}
			}
		}
		
		[Column(Storage="_quantityToSale", Name="quantity_to_sale", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int QuantityToSale
		{
			get
			{
				return this._quantityToSale;
			}
			set
			{
				if ((_quantityToSale != value))
				{
					this.OnQuantityToSaleChanging(value);
					this._quantityToSale = value;
					this.OnQuantityToSaleChanged();
				}
			}
		}
		
		[Column(Storage="_ratingCount", Name="rating_count", DbType="int unsigned", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public uint RatingCount
		{
			get
			{
				return this._ratingCount;
			}
			set
			{
				if ((_ratingCount != value))
				{
					this.OnRatingCountChanging(value);
					this._ratingCount = value;
					this.OnRatingCountChanged();
				}
			}
		}
		
		[Column(Storage="_ratingUsers", Name="rating_users", DbType="int unsigned", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public uint RatingUsers
		{
			get
			{
				return this._ratingUsers;
			}
			set
			{
				if ((_ratingUsers != value))
				{
					this.OnRatingUsersChanging(value);
					this._ratingUsers = value;
					this.OnRatingUsersChanged();
				}
			}
		}
	}
	
	[Table(Name="plush_mobile.top_movies")]
	public partial class TopMovies
	{
		
		private int _id;
		
		private string _image;
		
		private int _language;
		
		private string _name;
		
		#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnIDChanged();
		
		partial void OnIDChanging(int value);
		
		partial void OnImageChanged();
		
		partial void OnImageChanging(string value);
		
		partial void OnLanguageChanged();
		
		partial void OnLanguageChanging(int value);
		
		partial void OnNameChanged();
		
		partial void OnNameChanging(string value);
		#endregion
		
		
		public TopMovies()
		{
			this.OnCreated();
		}
		
		[Column(Storage="_id", Name="id", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int ID
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((_id != value))
				{
					this.OnIDChanging(value);
					this._id = value;
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_image", Name="image", DbType="varchar(7)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string Image
		{
			get
			{
				return this._image;
			}
			set
			{
				if (((_image == value) 
							== false))
				{
					this.OnImageChanging(value);
					this._image = value;
					this.OnImageChanged();
				}
			}
		}
		
		[Column(Storage="_language", Name="language", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int Language
		{
			get
			{
				return this._language;
			}
			set
			{
				if ((_language != value))
				{
					this.OnLanguageChanging(value);
					this._language = value;
					this.OnLanguageChanged();
				}
			}
		}
		
		[Column(Storage="_name", Name="name", DbType="varchar(255)", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public string Name
		{
			get
			{
				return this._name;
			}
			set
			{
				if (((_name == value) 
							== false))
				{
					this.OnNameChanging(value);
					this._name = value;
					this.OnNameChanged();
				}
			}
		}
	}

    [Table(Name = "plush_mobile.hp_menu")]
    public partial class HpMenu : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private System.Nullable<sbyte> _available;

        private int _id;

        private string _imG;

        private System.Nullable<int> _languageID;

        private string _methodUrl;

        private string _name;

        private System.Nullable<uint> _ordered;

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnAvailableChanged();

        partial void OnAvailableChanging(System.Nullable<sbyte> value);

        partial void OnIDChanged();

        partial void OnIDChanging(int value);

        partial void OnIMgChanged();

        partial void OnIMgChanging(string value);

        partial void OnLanguageIDChanged();

        partial void OnLanguageIDChanging(System.Nullable<int> value);

        partial void OnMethodURLChanged();

        partial void OnMethodURLChanging(string value);

        partial void OnNameChanged();

        partial void OnNameChanging(string value);

        partial void OnOrderedChanged();

        partial void OnOrderedChanging(System.Nullable<uint> value);
        #endregion


        public HpMenu()
        {
            this.OnCreated();
        }

        [Column(Storage = "_available", Name = "available", DbType = "tinyint(4)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> Available
        {
            get
            {
                return this._available;
            }
            set
            {
                if ((_available != value))
                {
                    this.OnAvailableChanging(value);
                    this.SendPropertyChanging();
                    this._available = value;
                    this.SendPropertyChanged("Available");
                    this.OnAvailableChanged();
                }
            }
        }

        [Column(Storage = "_id", Name = "id", DbType = "int", IsPrimaryKey = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int ID
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((_id != value))
                {
                    this.OnIDChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("ID");
                    this.OnIDChanged();
                }
            }
        }

        [Column(Storage = "_imG", Name = "img", DbType = "varchar(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string IMg
        {
            get
            {
                return this._imG;
            }
            set
            {
                if (((_imG == value)
                            == false))
                {
                    this.OnIMgChanging(value);
                    this.SendPropertyChanging();
                    this._imG = value;
                    this.SendPropertyChanged("IMg");
                    this.OnIMgChanged();
                }
            }
        }

        [Column(Storage = "_languageID", Name = "language_id", DbType = "int", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> LanguageID
        {
            get
            {
                return this._languageID;
            }
            set
            {
                if ((_languageID != value))
                {
                    this.OnLanguageIDChanging(value);
                    this.SendPropertyChanging();
                    this._languageID = value;
                    this.SendPropertyChanged("LanguageID");
                    this.OnLanguageIDChanged();
                }
            }
        }

        [Column(Storage = "_methodUrl", Name = "method_url", DbType = "varchar(150)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string MethodURL
        {
            get
            {
                return this._methodUrl;
            }
            set
            {
                if (((_methodUrl == value)
                            == false))
                {
                    this.OnMethodURLChanging(value);
                    this.SendPropertyChanging();
                    this._methodUrl = value;
                    this.SendPropertyChanged("MethodURL");
                    this.OnMethodURLChanged();
                }
            }
        }

        [Column(Storage = "_name", Name = "name", DbType = "varchar(45)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                if (((_name == value)
                            == false))
                {
                    this.OnNameChanging(value);
                    this.SendPropertyChanging();
                    this._name = value;
                    this.SendPropertyChanged("Name");
                    this.OnNameChanged();
                }
            }
        }

        [Column(Storage = "_ordered", Name = "ordered", DbType = "int unsigned", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<uint> Ordered
        {
            get
            {
                return this._ordered;
            }
            set
            {
                if ((_ordered != value))
                {
                    this.OnOrderedChanging(value);
                    this.SendPropertyChanging();
                    this._ordered = value;
                    this.SendPropertyChanged("Ordered");
                    this.OnOrderedChanged();
                }
            }
        }

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [Table(Name = "plush_mobile.hp_today_movie")]
    public partial class HpTodayMovie
    {

        private string _broadcast;

        private string _dcRp;

        private System.Nullable<long> _diskID;

        private int _id;

        private System.Nullable<int> _imdBIdseRie;

        private string _imG;

        private System.Nullable<int> _lngID;

        private string _name;

        private System.Nullable<int> _ordered;

        private System.Nullable<decimal> _rate;

        private System.Nullable<decimal> _seasonID;

        private string _trailer;

        private System.Nullable<int> _voD;

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnBroadcastChanged();

        partial void OnBroadcastChanging(string value);

        partial void OnDcRpChanged();

        partial void OnDcRpChanging(string value);

        partial void OnDiskIDChanged();

        partial void OnDiskIDChanging(System.Nullable<long> value);

        partial void OnIDChanged();

        partial void OnIDChanging(int value);

        partial void OnIMDbIDSErieChanged();

        partial void OnIMDbIDSErieChanging(System.Nullable<int> value);

        partial void OnIMgChanged();

        partial void OnIMgChanging(string value);

        partial void OnLNGiDChanged();

        partial void OnLNGiDChanging(System.Nullable<int> value);

        partial void OnNameChanged();

        partial void OnNameChanging(string value);

        partial void OnOrderedChanged();

        partial void OnOrderedChanging(System.Nullable<int> value);

        partial void OnRateChanged();

        partial void OnRateChanging(System.Nullable<decimal> value);

        partial void OnSeasonIDChanged();

        partial void OnSeasonIDChanging(System.Nullable<decimal> value);

        partial void OnTrailerChanged();

        partial void OnTrailerChanging(string value);

        partial void OnVOdChanged();

        partial void OnVOdChanging(System.Nullable<int> value);
        #endregion


        public HpTodayMovie()
        {
            this.OnCreated();
        }

        [Column(Storage = "_broadcast", Name = "broadcast", DbType = "varchar(40)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string Broadcast
        {
            get
            {
                return this._broadcast;
            }
            set
            {
                if (((_broadcast == value)
                            == false))
                {
                    this.OnBroadcastChanging(value);
                    this._broadcast = value;
                    this.OnBroadcastChanged();
                }
            }
        }

        [Column(Storage = "_dcRp", Name = "dcrp", DbType = "text", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string DcRp
        {
            get
            {
                return this._dcRp;
            }
            set
            {
                if (((_dcRp == value)
                            == false))
                {
                    this.OnDcRpChanging(value);
                    this._dcRp = value;
                    this.OnDcRpChanged();
                }
            }
        }

        [Column(Storage = "_diskID", Name = "disk_id", DbType = "bigint", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<long> DiskID
        {
            get
            {
                return this._diskID;
            }
            set
            {
                if ((_diskID != value))
                {
                    this.OnDiskIDChanging(value);
                    this._diskID = value;
                    this.OnDiskIDChanged();
                }
            }
        }

        [Column(Storage = "_id", Name = "id", DbType = "int", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int ID
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((_id != value))
                {
                    this.OnIDChanging(value);
                    this._id = value;
                    this.OnIDChanged();
                }
            }
        }

        [Column(Storage = "_imdBIdseRie", Name = "imdb_id_serie", DbType = "int", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> IMDbIDSErie
        {
            get
            {
                return this._imdBIdseRie;
            }
            set
            {
                if ((_imdBIdseRie != value))
                {
                    this.OnIMDbIDSErieChanging(value);
                    this._imdBIdseRie = value;
                    this.OnIMDbIDSErieChanged();
                }
            }
        }

        [Column(Storage = "_imG", Name = "img", DbType = "varchar(50)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string IMg
        {
            get
            {
                return this._imG;
            }
            set
            {
                if (((_imG == value)
                            == false))
                {
                    this.OnIMgChanging(value);
                    this._imG = value;
                    this.OnIMgChanged();
                }
            }
        }

        [Column(Storage = "_lngID", Name = "lngid", DbType = "int", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> LNGiD
        {
            get
            {
                return this._lngID;
            }
            set
            {
                if ((_lngID != value))
                {
                    this.OnLNGiDChanging(value);
                    this._lngID = value;
                    this.OnLNGiDChanged();
                }
            }
        }

        [Column(Storage = "_name", Name = "name", DbType = "varchar(64)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                if (((_name == value)
                            == false))
                {
                    this.OnNameChanging(value);
                    this._name = value;
                    this.OnNameChanged();
                }
            }
        }

        [Column(Storage = "_ordered", Name = "ordered", DbType = "int", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> Ordered
        {
            get
            {
                return this._ordered;
            }
            set
            {
                if ((_ordered != value))
                {
                    this.OnOrderedChanging(value);
                    this._ordered = value;
                    this.OnOrderedChanged();
                }
            }
        }

        [Column(Storage = "_rate", Name = "rate", DbType = "decimal(2,1)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<decimal> Rate
        {
            get
            {
                return this._rate;
            }
            set
            {
                if ((_rate != value))
                {
                    this.OnRateChanging(value);
                    this._rate = value;
                    this.OnRateChanged();
                }
            }
        }

        [Column(Storage = "_seasonID", Name = "season_id", DbType = "decimal(11,0)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<decimal> SeasonID
        {
            get
            {
                return this._seasonID;
            }
            set
            {
                if ((_seasonID != value))
                {
                    this.OnSeasonIDChanging(value);
                    this._seasonID = value;
                    this.OnSeasonIDChanged();
                }
            }
        }

        [Column(Storage = "_trailer", Name = "trailer", DbType = "text", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string Trailer
        {
            get
            {
                return this._trailer;
            }
            set
            {
                if (((_trailer == value)
                            == false))
                {
                    this.OnTrailerChanging(value);
                    this._trailer = value;
                    this.OnTrailerChanged();
                }
            }
        }

        [Column(Storage = "_voD", Name = "vod", DbType = "int", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> VOd
        {
            get
            {
                return this._voD;
            }
            set
            {
                if ((_voD != value))
                {
                    this.OnVOdChanging(value);
                    this._voD = value;
                    this.OnVOdChanged();
                }
            }
        }
    }

    [Table(Name = "plush_mobile.ctlg_central_menu")]
    public partial class CtLGCentralMenu : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private System.Nullable<sbyte> _available;

        private int _id;

        private string _imG;

        private System.Nullable<int> _languageID;

        private string _methodUrl;

        private string _name;

        private System.Nullable<uint> _ordered;

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnAvailableChanged();

        partial void OnAvailableChanging(System.Nullable<sbyte> value);

        partial void OnIDChanged();

        partial void OnIDChanging(int value);

        partial void OnIMgChanged();

        partial void OnIMgChanging(string value);

        partial void OnLanguageIDChanged();

        partial void OnLanguageIDChanging(System.Nullable<int> value);

        partial void OnMethodURLChanged();

        partial void OnMethodURLChanging(string value);

        partial void OnNameChanged();

        partial void OnNameChanging(string value);

        partial void OnOrderedChanged();

        partial void OnOrderedChanging(System.Nullable<uint> value);
        #endregion


        public CtLGCentralMenu()
        {
            this.OnCreated();
        }

        [Column(Storage = "_available", Name = "available", DbType = "tinyint(4)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> Available
        {
            get
            {
                return this._available;
            }
            set
            {
                if ((_available != value))
                {
                    this.OnAvailableChanging(value);
                    this.SendPropertyChanging();
                    this._available = value;
                    this.SendPropertyChanged("Available");
                    this.OnAvailableChanged();
                }
            }
        }

        [Column(Storage = "_id", Name = "id", DbType = "int", IsPrimaryKey = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int ID
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((_id != value))
                {
                    this.OnIDChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("ID");
                    this.OnIDChanged();
                }
            }
        }

        [Column(Storage = "_imG", Name = "img", DbType = "varchar(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string IMg
        {
            get
            {
                return this._imG;
            }
            set
            {
                if (((_imG == value)
                            == false))
                {
                    this.OnIMgChanging(value);
                    this.SendPropertyChanging();
                    this._imG = value;
                    this.SendPropertyChanged("IMg");
                    this.OnIMgChanged();
                }
            }
        }

        [Column(Storage = "_languageID", Name = "language_id", DbType = "int", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> LanguageID
        {
            get
            {
                return this._languageID;
            }
            set
            {
                if ((_languageID != value))
                {
                    this.OnLanguageIDChanging(value);
                    this.SendPropertyChanging();
                    this._languageID = value;
                    this.SendPropertyChanged("LanguageID");
                    this.OnLanguageIDChanged();
                }
            }
        }

        [Column(Storage = "_methodUrl", Name = "method_url", DbType = "varchar(150)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string MethodURL
        {
            get
            {
                return this._methodUrl;
            }
            set
            {
                if (((_methodUrl == value)
                            == false))
                {
                    this.OnMethodURLChanging(value);
                    this.SendPropertyChanging();
                    this._methodUrl = value;
                    this.SendPropertyChanged("MethodURL");
                    this.OnMethodURLChanged();
                }
            }
        }

        [Column(Storage = "_name", Name = "name", DbType = "varchar(45)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                if (((_name == value)
                            == false))
                {
                    this.OnNameChanging(value);
                    this.SendPropertyChanging();
                    this._name = value;
                    this.SendPropertyChanged("Name");
                    this.OnNameChanged();
                }
            }
        }

        [Column(Storage = "_ordered", Name = "ordered", DbType = "int unsigned", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<uint> Ordered
        {
            get
            {
                return this._ordered;
            }
            set
            {
                if ((_ordered != value))
                {
                    this.OnOrderedChanging(value);
                    this.SendPropertyChanging();
                    this._ordered = value;
                    this.SendPropertyChanged("Ordered");
                    this.OnOrderedChanged();
                }
            }
        }

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [Table(Name = "plush_mobile.ctlg_left_menu")]
    public partial class CtLGLeftMenu : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private System.Nullable<sbyte> _available;        

        private int _id;

        private string _imG;

        private System.Nullable<int> _languageID;

        private string _methodUrl;

        private string _name;

        private System.Nullable<uint> _ordered;

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnAvailableChanged();

        partial void OnAvailableChanging(System.Nullable<sbyte> value);

        partial void OnIDChanged();

        partial void OnIDChanging(int value);

        partial void OnIMgChanged();

        partial void OnIMgChanging(string value);

        partial void OnLanguageIDChanged();

        partial void OnLanguageIDChanging(System.Nullable<int> value);

        partial void OnMethodURLChanged();

        partial void OnMethodURLChanging(string value);

        partial void OnNameChanged();

        partial void OnNameChanging(string value);

        partial void OnOrderedChanged();

        partial void OnOrderedChanging(System.Nullable<uint> value);
        #endregion


        public CtLGLeftMenu()
        {
            this.OnCreated();
        }

        [Column(Storage = "_available", Name = "available", DbType = "tinyint(4)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> Available
        {
            get
            {
                return this._available;
            }
            set
            {
                if ((_available != value))
                {
                    this.OnAvailableChanging(value);
                    this.SendPropertyChanging();
                    this._available = value;
                    this.SendPropertyChanged("Available");
                    this.OnAvailableChanged();
                }
            }
        }

        [Column(Storage = "_id", Name = "id", DbType = "int", IsPrimaryKey = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int ID
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((_id != value))
                {
                    this.OnIDChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("ID");
                    this.OnIDChanged();
                }
            }
        }

        [Column(Storage = "_imG", Name = "img", DbType = "varchar(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string IMg
        {
            get
            {
                return this._imG;
            }
            set
            {
                if (((_imG == value)
                            == false))
                {
                    this.OnIMgChanging(value);
                    this.SendPropertyChanging();
                    this._imG = value;
                    this.SendPropertyChanged("IMg");
                    this.OnIMgChanged();
                }
            }
        }

        [Column(Storage = "_languageID", Name = "language_id", DbType = "int", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> LanguageID
        {
            get
            {
                return this._languageID;
            }
            set
            {
                if ((_languageID != value))
                {
                    this.OnLanguageIDChanging(value);
                    this.SendPropertyChanging();
                    this._languageID = value;
                    this.SendPropertyChanged("LanguageID");
                    this.OnLanguageIDChanged();
                }
            }
        }

        [Column(Storage = "_methodUrl", Name = "method_url", DbType = "varchar(150)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string MethodURL
        {
            get
            {
                return this._methodUrl;
            }
            set
            {
                if (((_methodUrl == value)
                            == false))
                {
                    this.OnMethodURLChanging(value);
                    this.SendPropertyChanging();
                    this._methodUrl = value;
                    this.SendPropertyChanged("MethodURL");
                    this.OnMethodURLChanged();
                }
            }
        }

        [Column(Storage = "_name", Name = "name", DbType = "varchar(45)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                if (((_name == value)
                            == false))
                {
                    this.OnNameChanging(value);
                    this.SendPropertyChanging();
                    this._name = value;
                    this.SendPropertyChanged("Name");
                    this.OnNameChanged();
                }
            }
        }

        [Column(Storage = "_ordered", Name = "ordered", DbType = "int unsigned", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<uint> Ordered
        {
            get
            {
                return this._ordered;
            }
            set
            {
                if ((_ordered != value))
                {
                    this.OnOrderedChanging(value);
                    this.SendPropertyChanging();
                    this._ordered = value;
                    this.SendPropertyChanged("Ordered");
                    this.OnOrderedChanged();
                }
            }
        }

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

}
