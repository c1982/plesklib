# plesklib
Simply Plesk .NET Library for version 12 and above

#Installation

You can directly install this project from [Nuget](https://www.nuget.org/packages/maestropanel.plesklib/). 

or

> **PM> Install-Package maestropanel.plesklib**

##Samples

**Create WebSpace**
```csharp
	var client = new PleskClient("192.168.5.5", "admin", "p@assW0rd!");
	var ipaddress = client.GetIPAddressList().ip.get.result.ipinfo.FirstOrDefault();

	var create = client.CreateWebSpace("domain.com", ipaddress.ipaddress);
	var result = create.ToResult();

	Console.WriteLine("Status: {0}", result.status);
	Console.WriteLine("Message: {0}", result.ErrorText);
	Console.WriteLine("New Webspace Id: {0}", create.webspace.add.result.Id);
```
----------

**Create WebSpace with Settings**
```csharp
	var client = new PleskClient("192.168.5.5", "admin", "p@assW0rd!");
	var ipaddress = client.GetIPAddressList().ip.get.result.ipinfo.FirstOrDefault();
	
	var list = new List<HostingProperty>();
	list.Add(new HostingProperty() { Name = "php", Value = "false" });
	list.Add(new HostingProperty() { Name = "ssi", Value = "false" });
	list.Add(new HostingProperty() { Name = "asp", Value = "true" });
	list.Add(new HostingProperty() { Name = "asp_dot_net", Value = "false" });
	list.Add(new HostingProperty() { Name = "cgi", Value = "true" });
	
	var create = client.CreateWebSpace("domain.com", ipaddress.ipaddress, list);
	var result = create.ToResult();
	
	Console.WriteLine("Status: {0}", result.status);
	Console.WriteLine("Message: {0}", result.ErrorText);
	Console.WriteLine("New Webspace Id: {0}", create.webspace.add.result.Id);
```
----------
**Create Subdomain**
```csharp
	var client = new PleskClient("192.168.5.5", "admin", "p@assW0rd!");
	
	var create = client.CreateSubdomain("domain.com", "blog");
	var result = create.ToResult();
	
	Console.WriteLine("Status: {0}", result.status);
	Console.WriteLine("Message: {0}", result.ErrorText);
	Console.WriteLine("New Webspace Id: {0}", create.subdomain.add.result.Id);
```

## API Actions

API actions taken on the roadmap. The completed ones are overlaid.

### Backups

- GET-REMOTE-STORAGE-SETTINGS retrieves settings of a remote FTP storage
- SET-REMOTE-STORAGE-SETTINGS changes settings of a remote FTP storage
- BACKUP-WEBSPACE creates a webspace-level backup task
- BACKUP-CUSTOMER creates a customer-level backup task
- BACKUP-RESELLER creates a reseller-level backup task
- BACKUP-SERVER creates a server-level backup task
- GET-TASKS-INFO retrieves the status of a certain backup task
- GET-LOCAL-BACKUP-LIST retrieves a list of backups stored in a local storage
- IMPORT-FILE moves backups from a temporary directory on a Plesk server to a local storage
- DOWNLOAD-FILE downloads a backup from the server
- GET-SUPPORTED-PROTOCOLS retrieves transport protocols supported by the backup-manager operator
- STOP-BACKUP cancels a certain backup task
- REMOVE-FILE removes a specified backup from a storage

### Databases

- ~~ADD-DB creates database entry of the specified type, defining the webspace that will use it.~~
- ~~DEL-DB removes database entry; If a database is used by an application installed on the server, it cannot be removed.~~
- ~~GET-DB retrieves database parameters by the ID, webspace name or webspace ID.~~
- ASSIGN-TO-SUBSCRIPTION moves a database to another subscription (webspace).
- SET-DEFAULT-USER specifies a default database user that Plesk uses for accessing the database.
- GET-DEFAULT-USER retrieves ID of administrator of a specified database.
- ~~ADD-DB-USER creates a database user account for a specified database.~~
- ~~DEL-DB-USER removes a database user account from a specified database.~~
- ~~GET-DB-USERS retrieves the list of users of a specified database and information about access control records for MySQL databases.~~
- ~~SET-DB-USER changes credentials of a database user and specifies hosts or IP addresses from which database users are allowed to connect to databases.~~

### DNS

- ADD_REC adds a DNS record of the specified type to the specified site zone
- GET_REC retrieves information about certain DNS records
- DEL_REC removes the specified DNS record(s)
- GET_ACL retrieves access control lists (ACL) from the server
- ADD_TO_ACL adds hosts to ACL
- REMOVE_FROM_ACL removes hosts from ACL
- SET updates the SOA record settings for the specified zone or zone template
- GET retrieves the SOA record settings
- SWITCH switches the DNS zone type between ‘master’ and ‘slave’
- ADD_MASTER_SERVER adds a new master DNS server for the specified zone
- GET_MASTER_SERVER retrieves the master server for the specified zone
- DEL_MASTER_SERVER removes the master server for the specified zone
- ENABLE enables the name server for the specified zone
- DISABLE disables the name server for the specified site
- ENABLE-REMOTE-DNS switches the DNS server to primary mode
- DISABLE-REMOTE-DNS switches the DNS server to slave mode
- GET-STATUS-REMOTE-DNS retrieves the status of the remote DNS server
- SET-RECURSION sets up preferences of recursive requests to DNS server
- GET-RECURSION retrieves the recursion preferences DNS server
- GET-SUPPORTED-RECURSION retrieves the available types of recursion for the DNS server

### FTP

- ~~ADD creates FTP account on a site specified by its name or ID~~
- SET changes properties of a specified FTP account
- ~~DEL deletes FTP account from a specified site~~
- GET retrieves information on properties of specified FTP accounts on particular sites

### IP Address

- ADD adds an IP address to Plesk server as shared or exclusive, specifying a netmask and server network interface
- ~~GET retrieves the list of IP addresses available on the server~~
- SET updates properties for IP addresses available on the server
- DEL removes an IP address from Plesk server

### Mail

- CREATE creates a mail account on a specified site and sets a collection of settings for it
- UPDATE serves to update mail account settings. It is specially designed to operate lists of mail group members, repository files, and automatic reply messages set for the mail account
- GET_INFO serves to retrieve various information about the specified mail accounts from Plesk database
- REMOVE removes the specified mail account and all its settings from Plesk database
- ENABLE turns on the mail service on the specified site
- DISABLE turns off the mail service on the specified site
- SET_PREFS sets mail service preferences for the specified sites
- GET_PREFS gets mail service preferences set for the specified sites
- RENAME renames the specified mail box

### Reseller Accounts

- ADD creates a reseller account.
- SET updates reseller account settings.
- GET retrieves information on reseller accounts.
- DEL removes reseller accounts.
- IPPOOL-ADD-IP adds IP addresses to a reseller's IP pool.
- IPPOOL-DEL-IP removes IP addresses from a reseller's IP pool.
- IPPOOL-SET-IP changes type of IP addresses (shared/exclusive) in a reseller's IP pool.
- CFORM-BUTTONS-LIST displays a buttons list for a reseller's home page.
- GET-LIMIT-DESCRIPTOR retrieves reseller limit descriptor.
- GET-PERMISSION-DESCRIPTOR retrieves reseller permission descriptor.
- CONVERT-TO-CUSTOMER converts a reseller account into a customer account.
- SWITCH-SUBSCRIPTION operation changes a reseller plan for a reseller account.
- SYNC-SUBSCRIPTION operation rolls reseller account settings back to the values defined in an associated reseller plan.
- ADD-PACKAGE includes an app in the specified reseller account.
- REMOVE-PACKAGE excludes an app from the specified reseller account.
- ENABLE-APS-FILTER excludes all apps from the specified reseller account.
- DISABLE-APS-FILTER includes all available apps in the specified reseller account.
- GET-DOMAIN-LIST retrieves information about all the reseller's domains.

### Sites (Domains)

- ~~ADD creates a site~~
- ~~GET retrieves site settings~~
- SET updates site settings
- ~~DEL removes the specified alias from the site~~
- CFORM_BUTTONS_LIST retrieves the list of custom buttons associated with given sites
- GET_TRAFFIC retrieves information on traffic spent by the sites between two dates
- SET_TRAFFIC sets information on traffic spent by the specified sites
- GET-PHYSICAL-HOSTING-DESCRIPTOR retrieves descriptor of hosting settings

### Site Aliases

- CREATE creates an alias for the specified site
- GET retrieves the alias settings for the alias specified by ID name, or the primary site ID, name
- SET updates the alias settings for the alias specified by ID name, or the primary site ID, name
- DELETE removes the specified alias from the site
- RENAME renames the alias related to the specified site
- GET-SUPPORTED-SERVICES retrieves the list of site alias supported services which can be managed on the server

### SSL

- INSTALL installs an SSL certificate to either Administrator's or specified webspace repository
- REMOVE removes the certificate with a specified name
- GENERATE generates a self-signed certificate
- GET_POOL retrieves a list of certificates for specified webspaces or a list of certificates from Administrator's repository.

### Subdomains

- ~~ADD creates a subdomain.v
- GET retrieves information on a specified subdomain from Plesk database.
- SET changes subdomain settings.
- ~~DEL removes a specified subdomain.~~
- RENAME renames a specified subdomain.

### Subscriptions (Webspaces)

- ~~ADD creates a subscription and sets general information, hosting settings, limits, preferences~~
- ~~GET retrieves information on subscriptions from Plesk database~~
- SET updates subscription settings in Plesk database
- ~~DEL removes subscriptions from Plesk database~~
- CFORM_BUTTONS_LIST retrieves list of buttons displayed on the webspace
- GET_TRAFFIC retrieves information on traffic spent by the site(s) between two dates
- SET_TRAFFIC sets information on traffic spent by the specified sites(s)
- GET-LIMIT-DESCRIPTOR retrieves descriptor of limits
- GET-PERMISSION-DESCRIPTOR retrieves descriptor of permissions
- GET-PHYSICAL-HOSTING-DESCRIPTOR retrieves descriptor of hosting settings
- SWITCH-SUBSCRIPTION switches a subscription to a different service plan
- SYNC-SUBSCRIPTION rolls back to settings defined by associated service plan
- ADD-SUBSCRIPTION adds a add-on plan to a subscription
- REMOVE-SUBSCRIPTION detaches an add-on plan from a subscription
- SET-BILLING-INFO saves information required for Plesk Billing in Plesk database
- ADD-PACKAGE adds an application to the specified subscription
- REMOVE-PACKAGE removes an application from the specified subscription
- ADD-PLAN-ITEM adds custom options of service plans (additional services) to the specified subscription
- REMOVE-PLAN-ITEM removes custom options of service plans (additional services) from the specified subscription
- ENABLE-APS-FILTER turns on applications list for specified subscriptions and makes available only added applications, by default all applications are available
- DISABLE-APS-FILTER turns off applications list for specified subscriptions and makes available all applications
- GET-CHANGED
- DB_SERVERS manages the list of database servers available within the specified subscription

### Virtual Directories

- ~~CREATE creates a virtual directory for the specified physical directory.~~
- UPDATE changes a virtual directory properties.
- ~~REMOVE deletes a virtual directory.~~
- GET retrieves information on a specified virtual directory from Plesk database.

