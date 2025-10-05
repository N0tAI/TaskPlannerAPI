-- Create database if it doesn't exist
-- Note: In Neon/PostgreSQL, CREATE DATABASE cannot be executed inside a transaction block
-- This script assumes it's run with sufficient privileges to create databases

DO $$
BEGIN
    IF NOT EXISTS (SELECT FROM pg_catalog.pg_roles WHERE rolname = 'planner_api') THEN
        -- Create user with password that should be set separately
        CREATE USER planner_api WITH LOGIN PASSWORD NULL;
        RAISE NOTICE 'User planner_api created. Please set a secure password using: ALTER USER planner_api PASSWORD ''your_secure_password'';';
    END IF;
END
$$;

-- Create the planner_app database owned by neondb_owner
SELECT 'CREATE DATABASE plannerdb'
WHERE NOT EXISTS (SELECT FROM pg_database WHERE datname = 'plannerdb')\gexec