# Interview Packaging

This document packages the project for interviews, recruiter follow-up, and technical conversations.

## 2-Minute Project Explanation

"I built a Mini ERP Inventory Management System to simulate the kind of internal business software used by operations-heavy companies. The app supports item master management, supplier management, purchase orders, goods receipt, inventory movements, reporting, and audit logging. I used React and TypeScript for the frontend, ASP.NET Core Web API for the backend, and PostgreSQL for the database.

What I wanted to show with this project was not just CRUD screens, but real ERP-style workflows. For example, receiving goods against a purchase order updates received quantities, increases inventory balances, creates inventory transactions, and leaves an audit trail. Issuing or adjusting stock also follows business rules and role restrictions. I documented the APIs with Swagger and added seeded demo data so the system can be demonstrated immediately.

The reason I think this project is relevant for ERP-oriented roles is that it focuses on business process integrity, traceability, and operational reporting rather than just UI. That maps well to the kind of work teams do on internal systems, including legacy ERP environments."

## System Architecture Explanation

Use this explanation in technical interviews:

"The project uses a standard three-tier web architecture. The React frontend handles routing, forms, protected pages, and API calls. The ASP.NET Core backend contains the business logic, validation, authorization, reporting queries, and audit logging. PostgreSQL stores transactional data such as users, items, suppliers, inventory balances, inventory transactions, purchase orders, goods receipts, and audit logs.

On the backend, I separated the code into API, Application, Domain, and Infrastructure layers. The Domain layer holds core business entities and rules. The Application layer defines interfaces and service contracts. Infrastructure handles EF Core persistence, authentication helpers, repositories, and service implementations. The API layer exposes the controllers, validation pipeline, auth configuration, Swagger, and error handling."

## Database Design Explanation

Use this when asked about the schema:

"I designed the database around traceability and transactional workflows. Instead of only storing a current item quantity, I separated inventory balances from inventory transactions. Inventory balances show the latest on-hand, reserved, and available quantity by item and location. Inventory transactions record the history of receipts, issues, and adjustments.

The core tables are users, roles, categories, items, suppliers, supplier-items, warehouses, locations, inventory-balances, inventory-transactions, purchase-orders, purchase-order-lines, goods-receipts, goods-receipt-lines, stock-adjustments, and audit-logs. Purchase orders and receipts are modeled separately so the system can track ordered quantity, received quantity, and status transitions. That structure makes reporting, operational troubleshooting, and auditability much easier."

## Why This Is Relevant To ERP

Use this when someone asks why this project matters:

- ERP systems are mainly about business workflows, data integrity, and traceability.
- This project models item master, procurement, receiving, stock movement, reporting, and audit history.
- It enforces role-based restrictions and workflow rules instead of treating everything like generic CRUD.
- It shows how operational data flows across modules instead of living in isolated screens.

Short answer:

"I built it to reflect how internal ERP software actually behaves. It connects purchasing, receiving, stock tracking, reporting, and audit history into one workflow-driven system."

## How This Maps To IBM i / RPG Business Systems

Use this when talking to companies working on IBM i, AS/400, or RPG:

"I know this project is built in a modern stack, but the business concepts map directly to what older ERP systems handle on IBM i. The core difference is the technology, not the operational logic. An RPG-based system might store and process the same business entities like items, suppliers, purchase orders, receipts, and inventory transactions, just with different language and platform conventions.

What I wanted to show is that I understand the domain model and workflow behavior. If a company uses IBM i and RPG for its ERP, I can still bring value because I already understand the business side: how stock should move, how receipts affect open purchase orders, how auditability matters, and how users rely on internal operational systems every day. Learning the platform is the next step, but the business thinking is already transferable." 

## Demo Walkthrough

Use this flow in a live demo:

1. Sign in as `admin@minierp.local`
2. Open the dashboard and explain KPI cards
3. Show the Items page and explain reorder levels and activation status
4. Show Suppliers and supplier-item mappings
5. Show Purchase Orders and open a detail page
6. Show Inventory balances and transaction history
7. Show Reports, especially low-stock and stock valuation
8. Show Audit Logs as the admin-only governance view

## Talking Points For Questions

### Hardest Part

"The hardest part was making the workflows feel like business software instead of disconnected CRUD pages. I had to connect purchase orders, receipts, inventory balances, transaction history, reporting, and audit logging in a consistent way."

### What You Would Improve Next

"I would add formal EF Core migrations, end-to-end browser tests, multi-warehouse transfers, and deployment to a public demo environment."

### What You Learned

"I learned a lot about modeling operational workflows carefully, especially how receiving, adjustments, and stock history affect multiple parts of the system at once."

## Sharing Checklist

Before sharing with a recruiter or interviewer:

1. Capture screenshots for the main pages in `docs/screenshots/`
2. Push the repo to GitHub
3. Verify the README quick-start still matches the local run process
4. If deployed, verify the hosted app and Swagger link
5. Keep demo credentials handy
