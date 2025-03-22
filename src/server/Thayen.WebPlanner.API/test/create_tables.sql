DROP TABLE IF EXISTS categories;
DROP TABLE IF EXISTS tasks;
DROP TABLE IF EXISTS milestones;
DROP TABLE IF EXISTS milestone_categories;
DROP TABLE IF EXISTS task_categories;
DROP TABLE IF EXISTS task_subtasks;
DROP TABLE IF EXISTS tasks_for_milestone;
DROP TABLE IF EXISTS milestones_for_task;

CREATE TABLE categories(
    id bigint GENERATED ALWAYS AS IDENTITY,
    name text NOT NULL
);
CREATE TABLE tasks(
    id bigint GENERATED ALWAYS AS IDENTITY,
    name text NOT NULL,
    priority int DEFAULT 0
);
CREATE TABLE milestones(
   id bigint GENERATED ALWAYS AS IDENTITY,
   name text NOT NULL,
   description text NULL
);

CREATE TABLE milestone_categories(
    milestone_id bigint REFERENCES milestones NOT NULL,
    category_id bigint REFERENCES categories NOT NULL,
    PRIMARY KEY (milestone_id, category_id)
);
CREATE TABLE task_categories(
    task_id bigint REFERENCES tasks NOT NULL,
    category_id bigint REFERENCES categories NOT NULL,
    PRIMARY KEY (task_id, category_id)
);

CREATE TABLE task_subtasks(
    task_id bigint REFERENCES tasks NOT NULL,
    subtask_id bigint REFERENCES tasks NOT NULL,
    PRIMARY KEY (task_id, subtask_id)
);

-- Tasks that belong to a milestone
CREATE TABLE tasks_for_milestone(
    id bigint GENERATED ALWAYS AS IDENTITY,
    milestone_id bigint REFERENCES milestones NOT NULL,
    task_id bigint REFERENCES tasks NOT NULL
);
-- Milestones that make up part of a task
CREATE TABLE milestones_for_task(
    id bigint GENERATED ALWAYS AS IDENTITY,
    task_id bigint REFERENCES tasks NOT NULL,
    milestone_id bigint REFERENCES milestones NOT NULL
)