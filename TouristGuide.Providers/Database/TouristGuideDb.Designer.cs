﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[assembly: EdmSchemaAttribute()]
#region EDM Relationship Metadata

[assembly: EdmRelationshipAttribute("TouristGuideDBModel", "FK_UserRoles_Roles", "Roles", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, typeof(TouristGuide.Providers.Database.Roles), "UserRoles", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(TouristGuide.Providers.Database.UserRoles), true)]
[assembly: EdmRelationshipAttribute("TouristGuideDBModel", "FK_UserRoles_Users", "Users", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, typeof(TouristGuide.Providers.Database.Users), "UserRoles", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(TouristGuide.Providers.Database.UserRoles), true)]

#endregion

namespace TouristGuide.Providers.Database
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class TouristGuideDBEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new TouristGuideDBEntities object using the connection string found in the 'TouristGuideDBEntities' section of the application configuration file.
        /// </summary>
        public TouristGuideDBEntities() : base("name=TouristGuideDBEntities", "TouristGuideDBEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new TouristGuideDBEntities object.
        /// </summary>
        public TouristGuideDBEntities(string connectionString) : base(connectionString, "TouristGuideDBEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new TouristGuideDBEntities object.
        /// </summary>
        public TouristGuideDBEntities(EntityConnection connection) : base(connection, "TouristGuideDBEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Roles> Roles
        {
            get
            {
                if ((_Roles == null))
                {
                    _Roles = base.CreateObjectSet<Roles>("Roles");
                }
                return _Roles;
            }
        }
        private ObjectSet<Roles> _Roles;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<UserRoles> UserRoles
        {
            get
            {
                if ((_UserRoles == null))
                {
                    _UserRoles = base.CreateObjectSet<UserRoles>("UserRoles");
                }
                return _UserRoles;
            }
        }
        private ObjectSet<UserRoles> _UserRoles;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Users> Users
        {
            get
            {
                if ((_Users == null))
                {
                    _Users = base.CreateObjectSet<Users>("Users");
                }
                return _Users;
            }
        }
        private ObjectSet<Users> _Users;

        #endregion

        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Roles EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToRoles(Roles roles)
        {
            base.AddObject("Roles", roles);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the UserRoles EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToUserRoles(UserRoles userRoles)
        {
            base.AddObject("UserRoles", userRoles);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Users EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToUsers(Users users)
        {
            base.AddObject("Users", users);
        }

        #endregion

    }

    #endregion

    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="TouristGuideDBModel", Name="Roles")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Roles : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Roles object.
        /// </summary>
        /// <param name="roleId">Initial value of the RoleId property.</param>
        public static Roles CreateRoles(global::System.Int32 roleId)
        {
            Roles roles = new Roles();
            roles.RoleId = roleId;
            return roles;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 RoleId
        {
            get
            {
                return _RoleId;
            }
            set
            {
                if (_RoleId != value)
                {
                    OnRoleIdChanging(value);
                    ReportPropertyChanging("RoleId");
                    _RoleId = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("RoleId");
                    OnRoleIdChanged();
                }
            }
        }
        private global::System.Int32 _RoleId;
        partial void OnRoleIdChanging(global::System.Int32 value);
        partial void OnRoleIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Role
        {
            get
            {
                return _Role;
            }
            set
            {
                OnRoleChanging(value);
                ReportPropertyChanging("Role");
                _Role = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Role");
                OnRoleChanged();
            }
        }
        private global::System.String _Role;
        partial void OnRoleChanging(global::System.String value);
        partial void OnRoleChanged();

        #endregion

    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("TouristGuideDBModel", "FK_UserRoles_Roles", "UserRoles")]
        public EntityCollection<UserRoles> UserRoles
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<UserRoles>("TouristGuideDBModel.FK_UserRoles_Roles", "UserRoles");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<UserRoles>("TouristGuideDBModel.FK_UserRoles_Roles", "UserRoles", value);
                }
            }
        }

        #endregion

    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="TouristGuideDBModel", Name="UserRoles")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class UserRoles : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new UserRoles object.
        /// </summary>
        /// <param name="userRoleId">Initial value of the UserRoleId property.</param>
        public static UserRoles CreateUserRoles(global::System.Int32 userRoleId)
        {
            UserRoles userRoles = new UserRoles();
            userRoles.UserRoleId = userRoleId;
            return userRoles;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 UserRoleId
        {
            get
            {
                return _UserRoleId;
            }
            set
            {
                if (_UserRoleId != value)
                {
                    OnUserRoleIdChanging(value);
                    ReportPropertyChanging("UserRoleId");
                    _UserRoleId = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("UserRoleId");
                    OnUserRoleIdChanged();
                }
            }
        }
        private global::System.Int32 _UserRoleId;
        partial void OnUserRoleIdChanging(global::System.Int32 value);
        partial void OnUserRoleIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> UserId
        {
            get
            {
                return _UserId;
            }
            set
            {
                OnUserIdChanging(value);
                ReportPropertyChanging("UserId");
                _UserId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("UserId");
                OnUserIdChanged();
            }
        }
        private Nullable<global::System.Int32> _UserId;
        partial void OnUserIdChanging(Nullable<global::System.Int32> value);
        partial void OnUserIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> RoleId
        {
            get
            {
                return _RoleId;
            }
            set
            {
                OnRoleIdChanging(value);
                ReportPropertyChanging("RoleId");
                _RoleId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("RoleId");
                OnRoleIdChanged();
            }
        }
        private Nullable<global::System.Int32> _RoleId;
        partial void OnRoleIdChanging(Nullable<global::System.Int32> value);
        partial void OnRoleIdChanged();

        #endregion

    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("TouristGuideDBModel", "FK_UserRoles_Roles", "Roles")]
        public Roles Roles
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Roles>("TouristGuideDBModel.FK_UserRoles_Roles", "Roles").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Roles>("TouristGuideDBModel.FK_UserRoles_Roles", "Roles").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Roles> RolesReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Roles>("TouristGuideDBModel.FK_UserRoles_Roles", "Roles");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Roles>("TouristGuideDBModel.FK_UserRoles_Roles", "Roles", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("TouristGuideDBModel", "FK_UserRoles_Users", "Users")]
        public Users Users
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Users>("TouristGuideDBModel.FK_UserRoles_Users", "Users").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Users>("TouristGuideDBModel.FK_UserRoles_Users", "Users").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Users> UsersReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Users>("TouristGuideDBModel.FK_UserRoles_Users", "Users");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Users>("TouristGuideDBModel.FK_UserRoles_Users", "Users", value);
                }
            }
        }

        #endregion

    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="TouristGuideDBModel", Name="Users")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Users : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Users object.
        /// </summary>
        /// <param name="userId">Initial value of the UserId property.</param>
        /// <param name="login">Initial value of the Login property.</param>
        /// <param name="password">Initial value of the Password property.</param>
        public static Users CreateUsers(global::System.Int32 userId, global::System.String login, global::System.String password)
        {
            Users users = new Users();
            users.UserId = userId;
            users.Login = login;
            users.Password = password;
            return users;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 UserId
        {
            get
            {
                return _UserId;
            }
            set
            {
                if (_UserId != value)
                {
                    OnUserIdChanging(value);
                    ReportPropertyChanging("UserId");
                    _UserId = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("UserId");
                    OnUserIdChanged();
                }
            }
        }
        private global::System.Int32 _UserId;
        partial void OnUserIdChanging(global::System.Int32 value);
        partial void OnUserIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Login
        {
            get
            {
                return _Login;
            }
            set
            {
                OnLoginChanging(value);
                ReportPropertyChanging("Login");
                _Login = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Login");
                OnLoginChanged();
            }
        }
        private global::System.String _Login;
        partial void OnLoginChanging(global::System.String value);
        partial void OnLoginChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Email
        {
            get
            {
                return _Email;
            }
            set
            {
                OnEmailChanging(value);
                ReportPropertyChanging("Email");
                _Email = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Email");
                OnEmailChanged();
            }
        }
        private global::System.String _Email;
        partial void OnEmailChanging(global::System.String value);
        partial void OnEmailChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Comment
        {
            get
            {
                return _Comment;
            }
            set
            {
                OnCommentChanging(value);
                ReportPropertyChanging("Comment");
                _Comment = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Comment");
                OnCommentChanged();
            }
        }
        private global::System.String _Comment;
        partial void OnCommentChanging(global::System.String value);
        partial void OnCommentChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Password
        {
            get
            {
                return _Password;
            }
            set
            {
                OnPasswordChanging(value);
                ReportPropertyChanging("Password");
                _Password = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Password");
                OnPasswordChanged();
            }
        }
        private global::System.String _Password;
        partial void OnPasswordChanging(global::System.String value);
        partial void OnPasswordChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String PasswordQuestion
        {
            get
            {
                return _PasswordQuestion;
            }
            set
            {
                OnPasswordQuestionChanging(value);
                ReportPropertyChanging("PasswordQuestion");
                _PasswordQuestion = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("PasswordQuestion");
                OnPasswordQuestionChanged();
            }
        }
        private global::System.String _PasswordQuestion;
        partial void OnPasswordQuestionChanging(global::System.String value);
        partial void OnPasswordQuestionChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String PasswordAnswer
        {
            get
            {
                return _PasswordAnswer;
            }
            set
            {
                OnPasswordAnswerChanging(value);
                ReportPropertyChanging("PasswordAnswer");
                _PasswordAnswer = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("PasswordAnswer");
                OnPasswordAnswerChanged();
            }
        }
        private global::System.String _PasswordAnswer;
        partial void OnPasswordAnswerChanging(global::System.String value);
        partial void OnPasswordAnswerChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Boolean> IsApproved
        {
            get
            {
                return _IsApproved;
            }
            set
            {
                OnIsApprovedChanging(value);
                ReportPropertyChanging("IsApproved");
                _IsApproved = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("IsApproved");
                OnIsApprovedChanged();
            }
        }
        private Nullable<global::System.Boolean> _IsApproved;
        partial void OnIsApprovedChanging(Nullable<global::System.Boolean> value);
        partial void OnIsApprovedChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> LastActivityDate
        {
            get
            {
                return _LastActivityDate;
            }
            set
            {
                OnLastActivityDateChanging(value);
                ReportPropertyChanging("LastActivityDate");
                _LastActivityDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("LastActivityDate");
                OnLastActivityDateChanged();
            }
        }
        private Nullable<global::System.DateTime> _LastActivityDate;
        partial void OnLastActivityDateChanging(Nullable<global::System.DateTime> value);
        partial void OnLastActivityDateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> LastLoginDate
        {
            get
            {
                return _LastLoginDate;
            }
            set
            {
                OnLastLoginDateChanging(value);
                ReportPropertyChanging("LastLoginDate");
                _LastLoginDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("LastLoginDate");
                OnLastLoginDateChanged();
            }
        }
        private Nullable<global::System.DateTime> _LastLoginDate;
        partial void OnLastLoginDateChanging(Nullable<global::System.DateTime> value);
        partial void OnLastLoginDateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> LastPasswordChangedDate
        {
            get
            {
                return _LastPasswordChangedDate;
            }
            set
            {
                OnLastPasswordChangedDateChanging(value);
                ReportPropertyChanging("LastPasswordChangedDate");
                _LastPasswordChangedDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("LastPasswordChangedDate");
                OnLastPasswordChangedDateChanged();
            }
        }
        private Nullable<global::System.DateTime> _LastPasswordChangedDate;
        partial void OnLastPasswordChangedDateChanging(Nullable<global::System.DateTime> value);
        partial void OnLastPasswordChangedDateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> CreationDate
        {
            get
            {
                return _CreationDate;
            }
            set
            {
                OnCreationDateChanging(value);
                ReportPropertyChanging("CreationDate");
                _CreationDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("CreationDate");
                OnCreationDateChanged();
            }
        }
        private Nullable<global::System.DateTime> _CreationDate;
        partial void OnCreationDateChanging(Nullable<global::System.DateTime> value);
        partial void OnCreationDateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Boolean> IsOnLine
        {
            get
            {
                return _IsOnLine;
            }
            set
            {
                OnIsOnLineChanging(value);
                ReportPropertyChanging("IsOnLine");
                _IsOnLine = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("IsOnLine");
                OnIsOnLineChanged();
            }
        }
        private Nullable<global::System.Boolean> _IsOnLine;
        partial void OnIsOnLineChanging(Nullable<global::System.Boolean> value);
        partial void OnIsOnLineChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Boolean> IsLockedOut
        {
            get
            {
                return _IsLockedOut;
            }
            set
            {
                OnIsLockedOutChanging(value);
                ReportPropertyChanging("IsLockedOut");
                _IsLockedOut = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("IsLockedOut");
                OnIsLockedOutChanged();
            }
        }
        private Nullable<global::System.Boolean> _IsLockedOut;
        partial void OnIsLockedOutChanging(Nullable<global::System.Boolean> value);
        partial void OnIsLockedOutChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> LastLockedOutDate
        {
            get
            {
                return _LastLockedOutDate;
            }
            set
            {
                OnLastLockedOutDateChanging(value);
                ReportPropertyChanging("LastLockedOutDate");
                _LastLockedOutDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("LastLockedOutDate");
                OnLastLockedOutDateChanged();
            }
        }
        private Nullable<global::System.DateTime> _LastLockedOutDate;
        partial void OnLastLockedOutDateChanging(Nullable<global::System.DateTime> value);
        partial void OnLastLockedOutDateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> FailedPasswordAttemptCount
        {
            get
            {
                return _FailedPasswordAttemptCount;
            }
            set
            {
                OnFailedPasswordAttemptCountChanging(value);
                ReportPropertyChanging("FailedPasswordAttemptCount");
                _FailedPasswordAttemptCount = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("FailedPasswordAttemptCount");
                OnFailedPasswordAttemptCountChanged();
            }
        }
        private Nullable<global::System.Int32> _FailedPasswordAttemptCount;
        partial void OnFailedPasswordAttemptCountChanging(Nullable<global::System.Int32> value);
        partial void OnFailedPasswordAttemptCountChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> FailedPasswordAttemptWindowStart
        {
            get
            {
                return _FailedPasswordAttemptWindowStart;
            }
            set
            {
                OnFailedPasswordAttemptWindowStartChanging(value);
                ReportPropertyChanging("FailedPasswordAttemptWindowStart");
                _FailedPasswordAttemptWindowStart = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("FailedPasswordAttemptWindowStart");
                OnFailedPasswordAttemptWindowStartChanged();
            }
        }
        private Nullable<global::System.DateTime> _FailedPasswordAttemptWindowStart;
        partial void OnFailedPasswordAttemptWindowStartChanging(Nullable<global::System.DateTime> value);
        partial void OnFailedPasswordAttemptWindowStartChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> FailedPasswordAnswerAttemptCount
        {
            get
            {
                return _FailedPasswordAnswerAttemptCount;
            }
            set
            {
                OnFailedPasswordAnswerAttemptCountChanging(value);
                ReportPropertyChanging("FailedPasswordAnswerAttemptCount");
                _FailedPasswordAnswerAttemptCount = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("FailedPasswordAnswerAttemptCount");
                OnFailedPasswordAnswerAttemptCountChanged();
            }
        }
        private Nullable<global::System.Int32> _FailedPasswordAnswerAttemptCount;
        partial void OnFailedPasswordAnswerAttemptCountChanging(Nullable<global::System.Int32> value);
        partial void OnFailedPasswordAnswerAttemptCountChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> FailedPasswordAnswerAttemptWindowStart
        {
            get
            {
                return _FailedPasswordAnswerAttemptWindowStart;
            }
            set
            {
                OnFailedPasswordAnswerAttemptWindowStartChanging(value);
                ReportPropertyChanging("FailedPasswordAnswerAttemptWindowStart");
                _FailedPasswordAnswerAttemptWindowStart = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("FailedPasswordAnswerAttemptWindowStart");
                OnFailedPasswordAnswerAttemptWindowStartChanged();
            }
        }
        private Nullable<global::System.DateTime> _FailedPasswordAnswerAttemptWindowStart;
        partial void OnFailedPasswordAnswerAttemptWindowStartChanging(Nullable<global::System.DateTime> value);
        partial void OnFailedPasswordAnswerAttemptWindowStartChanged();

        #endregion

    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("TouristGuideDBModel", "FK_UserRoles_Users", "UserRoles")]
        public EntityCollection<UserRoles> UserRoles
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<UserRoles>("TouristGuideDBModel.FK_UserRoles_Users", "UserRoles");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<UserRoles>("TouristGuideDBModel.FK_UserRoles_Users", "UserRoles", value);
                }
            }
        }

        #endregion

    }

    #endregion

    
}
