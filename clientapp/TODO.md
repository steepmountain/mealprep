# TODO
- Nutrinionix API
  - BUG: computed properties for ingredient name and ingredient unit will both trigger another search when set through the previous search. this means they can trigger each other multiple times in a row. stop this.
- ASP.NET Core 2.2 backend
	- JWT for Cookie authentication in the SPA
	- Identity or IdentityServer4 for the user account?
- https://damienbod.com/2019/10/04/building-and-securing-an-asp-net-core-api-with-a-hosted-vue-js-ui/
  - https://github.com/damienbod/AspNetCoreMvcVueJs/tree/master/StsServerIdentity
  - https://identityserver4.readthedocs.io/en/latest/