-- Insert default achievements and content groups into database

DELETE FROM achieved;
DELETE FROM achievements;
INSERT INTO achievements (name, description, reward) VALUES 
    ("Taking inventory...",  "Open the inventory",          1),
    ("Grumpy",               "More ore!",                   1),
    ("Bashful",              "More ore!",                   1),
    ("Dopey",                "More ore!",                   1),
    ("It's all mine",        "Collect ALL the ore",        11),
    ("Finding Nome",         "Blub blub blub...",           1),
    ("Finding Dyro",         "Blub blub blub...",           1),
    ("Ocean man",            "Catch ALL the fish",        101),
    ("Run Forest, run!",     "Bark bark bark...",           1),
    ("Timber!!!",            "Bark bark bark...",           1),
    ("It's treeson!",        "Bark bark bark...",           1),
    ("Mourning wood",        "Kill ALL the trees",        131),
    ("What a steal!",        "Pickpocket the yeti",       151),
    ("Yak whisperer",        "Tip the yak over",          181),
    ("TNT I'm Zygomite",     "Calm down the Zygomite",    191),
    ("Crab rave",            "Tap the crab just right",   313),
    ("King of the Slimes",   "Defeat the king slime",     353),
    ("Mr. smartypants",      "Solve ALL the puzzles",     373);

DELETE FROM content;
INSERT INTO content (name, enabled) VALUES
    ("resource",  1),
    ("challenge", 1);
