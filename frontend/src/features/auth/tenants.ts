export const TENANTS = [
  {
    slug: "furniture",
    name: "ClearFurniture Corp",
    industry: "Furniture",
    admin: { email: "admin@clearfurniture.local", password: "Admin123!" },
    warehouse: { email: "warehouse@clearfurniture.local", password: "Warehouse123!" },
  },
  {
    slug: "electronics",
    name: "TechFlow Electronics",
    industry: "Electronics",
    admin: { email: "admin@techflow-electronics.local", password: "Admin123!" },
    warehouse: { email: "warehouse@techflow-electronics.local", password: "Warehouse123!" },
  },
  {
    slug: "food-beverage",
    name: "FreshFoods Co",
    industry: "Food & Beverage",
    admin: { email: "admin@freshfoods.local", password: "Admin123!" },
    warehouse: { email: "warehouse@freshfoods.local", password: "Warehouse123!" },
  },
  {
    slug: "saas",
    name: "CloudPeak SaaS",
    industry: "SaaS / Cloud",
    admin: { email: "admin@cloudpeak.local", password: "Admin123!" },
    warehouse: { email: "warehouse@cloudpeak.local", password: "Warehouse123!" },
  },
  {
    slug: "it-services",
    name: "NetBridge IT Services",
    industry: "IT Services",
    admin: { email: "admin@netbridge.local", password: "Admin123!" },
    warehouse: { email: "warehouse@netbridge.local", password: "Warehouse123!" },
  },
  {
    slug: "cybersecurity",
    name: "ShieldCore Cybersecurity",
    industry: "Cybersecurity",
    admin: { email: "admin@shieldcore.local", password: "Admin123!" },
    warehouse: { email: "warehouse@shieldcore.local", password: "Warehouse123!" },
  },
] as const;

export type Tenant = (typeof TENANTS)[number];
export type TenantSlug = Tenant["slug"];
