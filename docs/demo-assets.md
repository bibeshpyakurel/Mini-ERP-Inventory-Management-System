# Demo Assets

Use this as the minimum asset checklist before sharing the project externally.

## Screenshots To Capture

- `docs/screenshots/login-page.png`
- `docs/screenshots/dashboard.png`
- `docs/screenshots/items-page.png`
- `docs/screenshots/suppliers-page.png`
- `docs/screenshots/purchase-orders-page.png`
- `docs/screenshots/purchase-order-detail-page.png`
- `docs/screenshots/inventory-page.png`
- `docs/screenshots/reports-page.png`
- `docs/screenshots/audit-logs-page.png`

## Suggested Demo Video Flow

If you record a short demo, keep it under 3 minutes:

1. Open the login page
2. Sign in with the admin account
3. Show the dashboard
4. Open Items
5. Open Purchase Orders
6. Open Inventory
7. Open Reports
8. Open Audit Logs
9. End on the GitHub repository README

## Deployment Notes

Recommended deployment path:

- frontend: Vercel or Netlify
- backend: Render, Railway, or Azure App Service
- database: Neon, Supabase, or Railway PostgreSQL

Before deploying:

1. replace local URLs in frontend env config
2. move from `EnsureCreated()` to EF Core migrations
3. use production secrets for JWT and database credentials
4. verify CORS settings for the hosted frontend domain
