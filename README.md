# School website

A school website built in ASP.NET MVC in 2018. Beyond the public pages it carries three things worth
looking at:

- **ASP.NET Identity** login with the standard account and profile management flows
- **QR-code student lookup** — a QR controller that resolves a scanned code to a student record
- **Biometric attendance** — a ZKTeco device module that pulls attendance logs off the hardware and
  into the site's database

## Credit

The biometric module under `Zkem_Att_module/Utilities` is **derived work**, originally by
**Ozesh Thapa** — the attribution is preserved in the file headers.

**Built with:** C# · ASP.NET MVC · ASP.NET Identity · Entity Framework · SQL Server · ZKTeco
`zkemkeeper` SDK

**Running it:** open the solution in Visual Studio and **set your own connection string** in
`Web.config` before running. The values that shipped here originally pointed at a database that no
longer exists.

**Status:** archived. A 2018 client project, kept for reference and not maintained.
