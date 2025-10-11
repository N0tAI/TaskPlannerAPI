DROP TABLE IF EXISTS planner.tasks;

CREATE TABLE planner.tasks (
    task_id UUID NOT NULL DEFAULT uuid_generate_v7 (),
    name VARCHAR(64) NOT NULL,
    description VARCHAR(1024) NOT NULL DEFAULT '',
    priority INT NOT NULL DEFAULT 0,
    completion_date TIMESTAMPTZ DEFAULT NULL,
    parent_task_id UUID DEFAULT NULL REFERENCES planner.tasks (task_id),
    PRIMARY KEY (task_id)
);

DROP TABLE IF EXISTS planner.categories;

CREATE TABLE planner.categories (
    category_id UUID NOT NULL DEFAULT uuid_generate_v7 (),
    name VARCHAR(64) NOT NULL,
    PRIMARY KEY (category_id),
)

DROP TABLE IF EXISTS planner.task_categories;

CREATE TABLE planner.task_categories (
    task_id NOT NULL REFERENCES planner.tasks (task_id) ON DELETE CASCADE,
    category_id NOT NULL REFERENCES planner.categories (category_id) ON DELETE CASCADE,
    category_z_index INT NOT NULL DEFAULT 0,
    PRIMARY KEY (task_id, category_id),
);