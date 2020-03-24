# Writer's Club

## By Krista Rutz and Steven Fleming

- Writers Club

- Users
  - Groups of Users/ Publication
  - agree to enter into a Writing Journal

Zine/Writing Journal

- Stores these Entries and prompts
- Prompts
  - Users can create and store promts
  - specify paramters for the prompts
  - specify parameters for the entries
- Entries

Journal

week 1 prompt

- entry jim
- entry steve
- entry krista

week 2 prompt

- entry jim
- entry steve
- entry krista

Club - "back end boys"

users are fixed (3)

Journal - "The boys go to the Beach"
Volume 1 - a single Journal issue
{
week 1 prompt

- entry jim
- entry steve
- entry krista
  }

Volume 2 - a single Journal issue
{
week 2 prompt

- entry jim
- entry steve
- entry krista
  }

Journal 2 - "The boys go to the club"
Volume 1 - a single Journal issue
{
week 1 prompt

- entry jim
- entry steve
- entry krista
  }

Volume 2 - a single Journal issue
{
week 2 prompt

- entry jim
- entry steve
- entry krista
  }

Parallels

- ToDoList = WritersClub
- ApplicationUser = ApplicationUser
- Item = Entry
  - Item.Description = Entry.Content
- Category = Issue
  - Category.Name = Issue.Prompt
- CategoryItem => unnecessary

New Stuff

- Club: group of users
- join class: ApplicationUserClub (shows which clubs a single user is part of, which users are members of a single club)
- Journal: group of Issues

Relationships

- User <=> Club - Many to Many
- Journal => Club - Many to One
- Entry => Issue - Many to One
- Issues => Journal - Many to One
