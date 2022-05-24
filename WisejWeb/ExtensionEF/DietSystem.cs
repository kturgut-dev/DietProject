// Licence file C:\Users\kturgut\Documents\ReversePOCO.txt not found.
// Please obtain your licence file at www.ReversePOCO.co.uk, and place it in your documents folder shown above.
// Defaulting to Trial version.


// ------------------------------------------------------------------------------------------------
// WARNING: Failed to load provider "System.Data.SqlClient" - A network-related or instance-specific error occurred while establishing a connection to SQL Server. The server was not found or was not accessible. Verify that the instance name is correct and that SQL Server is configured to allow remote connections. (provider: SQL Network Interfaces, error: 26 - Error Locating Server/Instance Specified)
// Allowed providers:
//    "System.Data.Odbc"
//    "System.Data.OleDb"
//    "System.Data.OracleClient"
//    "System.Data.SqlClient"
//    "MySql.Data.MySqlClient"
//    "Microsoft.SqlServerCe.Client.4.0"

/*   at System.Data.SqlClient.SqlInternalConnectionTds..ctor(DbConnectionPoolIdentity identity, SqlConnectionString connectionOptions, SqlCredential credential, Object providerInfo, String newPassword, SecureString newSecurePassword, Boolean redirectedUserInstance, SqlConnectionString userConnectionOptions, SessionData reconnectSessionData, DbConnectionPool pool, String accessToken, Boolean applyTransientFaultHandling, SqlAuthenticationProviderManager sqlAuthProviderManager)
   at System.Data.SqlClient.SqlConnectionFactory.CreateConnection(DbConnectionOptions options, DbConnectionPoolKey poolKey, Object poolGroupProviderInfo, DbConnectionPool pool, DbConnection owningConnection, DbConnectionOptions userOptions)
   at System.Data.ProviderBase.DbConnectionFactory.CreatePooledConnection(DbConnectionPool pool, DbConnection owningObject, DbConnectionOptions options, DbConnectionPoolKey poolKey, DbConnectionOptions userOptions)
   at System.Data.ProviderBase.DbConnectionPool.CreateObject(DbConnection owningObject, DbConnectionOptions userOptions, DbConnectionInternal oldConnection)
   at System.Data.ProviderBase.DbConnectionPool.UserCreateRequest(DbConnection owningObject, DbConnectionOptions userOptions, DbConnectionInternal oldConnection)
   at System.Data.ProviderBase.DbConnectionPool.TryGetConnection(DbConnection owningObject, UInt32 waitForMultipleObjectsTimeout, Boolean allowCreate, Boolean onlyOneCheckConnection, DbConnectionOptions userOptions, DbConnectionInternal& connection)
   at System.Data.ProviderBase.DbConnectionPool.TryGetConnection(DbConnection owningObject, TaskCompletionSource`1 retry, DbConnectionOptions userOptions, DbConnectionInternal& connection)
   at System.Data.ProviderBase.DbConnectionFactory.TryGetConnection(DbConnection owningConnection, TaskCompletionSource`1 retry, DbConnectionOptions userOptions, DbConnectionInternal oldConnection, DbConnectionInternal& connection)
   at System.Data.ProviderBase.DbConnectionInternal.TryOpenConnectionInternal(DbConnection outerConnection, DbConnectionFactory connectionFactory, TaskCompletionSource`1 retry, DbConnectionOptions userOptions)
   at System.Data.SqlClient.SqlConnection.TryOpenInner(TaskCompletionSource`1 retry)
   at System.Data.SqlClient.SqlConnection.TryOpen(TaskCompletionSource`1 retry)
   at System.Data.SqlClient.SqlConnection.Open()
   at Microsoft.VisualStudio.TextTemplatingAAD8A2BDEABB6FFCACE129FD81632A139B462F35851D146C4D7533806AF7887B8660C1D0C3C8FC85176B227D5BCFF690B69D54934CC7551733F8CAF9AB1F20CF.GeneratedTextTransformation.DatabaseReader.Init() in C:\Users\kturgut\source\repos\kturgut-dev\DietProject\WisejWeb\ExtensionEF\EF.Reverse.POCO.v3.ttinclude:line 12200
   at Microsoft.VisualStudio.TextTemplatingAAD8A2BDEABB6FFCACE129FD81632A139B462F35851D146C4D7533806AF7887B8660C1D0C3C8FC85176B227D5BCFF690B69D54934CC7551733F8CAF9AB1F20CF.GeneratedTextTransformation.SqlServerDatabaseReader.Init() in C:\Users\kturgut\source\repos\kturgut-dev\DietProject\WisejWeb\ExtensionEF\EF.Reverse.POCO.v3.ttinclude:line 15604
   at Microsoft.VisualStudio.TextTemplatingAAD8A2BDEABB6FFCACE129FD81632A139B462F35851D146C4D7533806AF7887B8660C1D0C3C8FC85176B227D5BCFF690B69D54934CC7551733F8CAF9AB1F20CF.GeneratedTextTransformation.Generator.Init(DatabaseReader databaseReader, String singleDbContextSubNamespace) in C:\Users\kturgut\source\repos\kturgut-dev\DietProject\WisejWeb\ExtensionEF\EF.Reverse.POCO.v3.ttinclude:line 4138
   at Microsoft.VisualStudio.TextTemplatingAAD8A2BDEABB6FFCACE129FD81632A139B462F35851D146C4D7533806AF7887B8660C1D0C3C8FC85176B227D5BCFF690B69D54934CC7551733F8CAF9AB1F20CF.GeneratedTextTransformation.GeneratorFactory.Create(FileManagementService fileManagementService, Type fileManagerType, String singleDbContextSubNamespace) in C:\Users\kturgut\source\repos\kturgut-dev\DietProject\WisejWeb\ExtensionEF\EF.Reverse.POCO.v3.ttinclude:line 6284*/
// ------------------------------------------------------------------------------------------------

