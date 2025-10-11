DROP TABLE IF EXISTS planner.task_categories;
DROP TABLE IF EXISTS planner.categories;
DROP TABLE IF EXISTS planner.tasks;

CREATE TABLE planner.tasks (
    task_id UUID NOT NULL DEFAULT uuid_generate_v7(),
    name VARCHAR(64) NOT NULL,
    description VARCHAR(1024) NOT NULL DEFAULT '',
    priority INT NOT NULL DEFAULT 0,
    completion_date TIMESTAMPTZ DEFAULT NULL,
    parent_task_id UUID DEFAULT NULL REFERENCES planner.tasks (task_id),
    PRIMARY KEY (task_id)
);

CREATE TABLE planner.categories (
    category_id UUID NOT NULL DEFAULT uuid_generate_v7(),
    name VARCHAR(64) NOT NULL,
    PRIMARY KEY (category_id)
);

CREATE TABLE planner.task_categories (
    task_id UUID NOT NULL REFERENCES planner.tasks (task_id) ON DELETE CASCADE,
    category_id UUID NOT NULL REFERENCES planner.categories (category_id) ON DELETE CASCADE,
    category_z_index INT NOT NULL DEFAULT 0,
    PRIMARY KEY (task_id, category_id)
);

INSERT INTO planner.categories (category_id, name) VALUES
('550e8400-e29b-41d4-a716-446655440000', 'Work'),
('550e8400-e29b-41d4-a716-446655440001', 'Personal'),
('550e8400-e29b-41d4-a716-446655440002', 'Urgent'),
('550e8400-e29b-41d4-a716-446655440003', 'Health'),
('550e8400-e29b-41d4-a716-446655440004', 'Education');

INSERT INTO planner.tasks (task_id, name, description, priority, completion_date, parent_task_id) VALUES
('660e8400-e29b-41d4-a716-446655440000', 'Complete project report', 'Write and submit the quarterly project report', 3, NULL, NULL),
('660e8400-e29b-41d4-a716-446655440001', 'Buy groceries', 'Purchase weekly groceries from the store', 1, '2023-10-05T10:00:00Z', NULL),
('660e8400-e29b-41d4-a716-446655440002', 'Exercise routine', 'Daily 30-minute workout session', 2, NULL, NULL),
('660e8400-e29b-41d4-a716-446655440003', 'Read book', 'Finish reading "The Pragmatic Programmer"', 1, NULL, NULL),
('660e8400-e29b-41d4-a716-446655440004', 'Fix bug in code', 'Resolve the null pointer exception in the login module', 4, '2023-10-06T14:30:00Z', NULL),
('660e8400-e29b-41d4-a716-446655440005', 'Plan vacation', 'Research and book flights for summer vacation', 2, NULL, NULL),
('660e8400-e29b-41d4-a716-446655440006', 'Attend meeting', 'Participate in the team stand-up meeting', 3, NULL, '660e8400-e29b-41d4-a716-446655440000'),
('660e8400-e29b-41d4-a716-446655440007', 'Clean house', 'Deep clean the living room and kitchen', 1, NULL, NULL),
('660e8400-e29b-41d4-a716-446655440008', 'Learn new skill', 'Take an online course on machine learning', 2, NULL, NULL),
('660e8400-e29b-41d4-a716-446655440009', 'Call dentist', 'Schedule an appointment for dental check-up', 3, NULL, NULL);

INSERT INTO planner.task_categories (task_id, category_id, category_z_index) VALUES
('660e8400-e29b-41d4-a716-446655440000', '550e8400-e29b-41d4-a716-446655440000', 1),
('660e8400-e29b-41d4-a716-446655440000', '550e8400-e29b-41d4-a716-446655440002', 2),
('660e8400-e29b-41d4-a716-446655440001', '550e8400-e29b-41d4-a716-446655440001', 1),
('660e8400-e29b-41d4-a716-446655440002', '550e8400-e29b-41d4-a716-446655440003', 1),
('660e8400-e29b-41d4-a716-446655440003', '550e8400-e29b-41d4-a716-446655440001', 1),
('660e8400-e29b-41d4-a716-446655440003', '550e8400-e29b-41d4-a716-446655440004', 2),
('660e8400-e29b-41d4-a716-446655440004', '550e8400-e29b-41d4-a716-446655440000', 1),
('660e8400-e29b-41d4-a716-446655440004', '550e8400-e29b-41d4-a716-446655440002', 2),
('660e8400-e29b-41d4-a716-446655440005', '550e8400-e29b-41d4-a716-446655440001', 1),
('660e8400-e29b-41d4-a716-446655440006', '550e8400-e29b-41d4-a716-446655440000', 1),
('660e8400-e29b-41d4-a716-446655440007', '550e8400-e29b-41d4-a716-446655440001', 1),
('660e8400-e29b-41d4-a716-446655440008', '550e8400-e29b-41d4-a716-446655440004', 1),
('660e8400-e29b-41d4-a716-446655440009', '550e8400-e29b-41d4-a716-446655440003', 1);