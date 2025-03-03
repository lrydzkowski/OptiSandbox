# OptiSandbox

A sandbox for different experiments with:

- [Optimizely CMS 12](https://docs.developers.optimizely.com/content-management-system/docs/getting-started)
- [Optimizely Customized Commerce 14](https://docs.developers.optimizely.com/customized-commerce/docs/system-overview)
- [Optimizely Search & Navigation](https://docs.developers.optimizely.com/digital-experience-platform/v1.1.0-search-and-navigation/docs/getting-started)

## How to Run It

1. Create an empty SQL Server database.
2. Add database connection string to `secrets.json`:

    ```json
    {
      "ConnectionStrings": {
        "EPiServerDB": "Server=192.168.50.50,49743;Database=OptiSandboxCms;User Id=OptiSandboxUser;Password=g23g4gv$RWEGXbxc_3;TrustServerCertificate=True;"
      }
    }
    ```

3. Create a demo find index: <https://find.optimizely.com/>.
4. Add index configuration to `secrets.json`:

    ```json
    {
      "EPiServer": {
        "Find": {
          "DefaultIndex": "{index_name}",
          "ServiceUrl": "{index_url}"
        }
      }
    }
    ```

5. Add the following to `hosts` file:

    ```text
    127.0.0.1 opti-sandbox.us
    127.0.0.1 opti-sandbox.pl
    ```

## Local Urls

- <https://opti-sandbox.us>
- <https://opti-sandbox.pl>
