# OnlineStoreConsoleApp
The Online store is learning project - a virtual store in the console, where customers can browse the catalog and select products of interest. The selected items may be collected to the order. Managers can create products, update and delete them. The project based on .NET 4.7.2.
# Purpose of App
The Online store is a virtual store where customers can browse the catalog and select products of interest. The selected items may be collected to the order. At that time, more information will be needed to complete the transaction. The customer will be asked to fill or select a shipping address, payment information such as a credit card number, mobile phone number and personal data. This information will be asked during registration.
# Installation Guide
1) Download the project zip folder or clone the repository into your computer (master branch).
2) Run the project via Visual Studio.
3) Create new database with help of migration in Package Manager Console:

```bash
enable-migrations
add-migraion init1 /migration name/
update-database
```
4) Run the project.     
