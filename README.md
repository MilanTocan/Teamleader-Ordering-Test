# Teamleader-Ordering-Test
ASP.NET MVC5 implementation of the Teamleader coding test 2

In the root of the solution you'll find the `web.config` file, you'll need to edit the ConnectionString property inside the `<appSetting>` tags
```sh
<add key="OrderingConnectionString" value="Data Source=DESKTOP-J2V7BBN\SQLEXPRESS;Initial Catalog=TeamLeaderOrdering;Persist Security Info=True;User ID=sa;Password=******"/>
```

Once this is done you use the `Update-Database` command in the Package Manager Console to create and seed the database.

# Features
- Single Page application
- Strong model binding
- jQuery and Ajax
- Use of the ValidationToken (even with Ajax calls)
- Use of the repository pattern
- Use of Data Attributes
- CSS Animations