# LSUVGD16
How to use git with command line.

git clone https://github.com/Vudude/LSUVGD16.git

to intially get the project. Open the project folder in Unity and everything should be fine.

git branch "whatever the name of the branch is"

in order to create a branch.

git checkout "the name of the branch" 

in order to change to a particular branch.
Once in the branch, you can work on the project.

After making changes, use

git add .

to add your changed files to what you're going to commit

and

git commit

to actually commit the changes to your LOCAL repo and then

git push

to push the changes to the actual web repo for everyone else.
Then you can go on the git project and make a pull request if your change is basically final. Don't merge the pull request yourself let someone else look it over.

# Rebasing or how to update your branch to what's on the master.

git checkout master

to change to what your LOCAL master is.

git fetch --prune origin 

in order to download the newest updates to master and

git reset --hard origin/master

in order to reset your local master to the updated master. Then, go to your branch with git checkout "your-branch" and use

git rebase -i master 

in order to rebase your branch on top of master.

# Windows Shell

cd - change directory 

cd .. - directory above current

ls - lists all files in current directory





FOR ETHAN'S USE ONLY

Drag all files into unity editor. Open Git Shell application.

cd LSUVGD16

git checkout master

git fetch 

git reset --hard origin/master

git branch ethan/animations

git checkout ethan/animations

git add .

git commit 

A popup notedpad editor will show up. Write in a description like Add animations at the very top and save and exit.

git push
