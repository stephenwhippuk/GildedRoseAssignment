Gilded​ ​Rose​ ​problem​ ​adapted​ ​from​ ​Gilded​ ​Rose​ ​Kata​ b​ y https://twitter.com/TerryHughes
Hi and welcome to team Gilded Rose. We are a small inn with a prime location in a
prominent city ran by a friendly innkeeper named Allison. We also buy and sell only the
finest goods. Unfortunately, our goods are constantly degrading in quality as they approach
their sell by date. We currently update our inventory manually.
Your task is to write a program to automate the inventory management based on the
following rules:
Rules​:
● All items have a SellIn value which denotes the number of days we have to sell the
item
● All items have a Quality value which denotes how valuable the item is
● At the end of each day our system lowers both values for every item
● Once the sell by date has passed, Quality degrades twice as fast
● The Quality of an item is never negative
● "Aged Brie" actually increases in Quality the older it gets
● “Normal Item” decreases in Quality by 1
● The Quality of an item is never more than 50
● "Sulfuras", being a legendary item, never has to be sold or decreases in Quality
● "Backstage passes", like aged brie, increases in Quality as its SellIn value
approaches; Its quality increases by 2 when there are 10 days or less and by 3 when
there are 5 days or less but quality drops to 0 after the concert
● "Conjured" items degrade in Quality twice as fast as normal items
Input:​ ​A list of items in the current inventory. Each line in the input represents an inventory
item with Item name, its sell-in value and quality e.g. “Backstage passes -1 2” => Backstage
passes is past sellin value by 1 day with quality 2.
Output​: Updated inventory after adjusting the quality and sellin days for each item after a
day.
Test​ ​Input​:
Aged Brie 1 1
Backstage passes -1 2
Backstage passes 9 2
Sulfuras 2 2
Normal Item -1 55
Normal Item 2 2
INVALID ITEM 2 2
Conjured 2 2
Conjured -1 5
Expected​ ​Output​:
Aged Brie 0 2
Backstage passes -2 0
Backstage passes 8 4
Sulfuras 2 2
Normal Item -2 50
Normal Item 1 1
NO SUCH ITEM
Conjured 1 0
Conjured -2 1
Notes​:
You may use external libraries or tools for building or testing purposes e.g. (JUnit, NUnit,
Xunit etc). You should NOT use any executables (e.g. bat, class, cmd, exe, jar, jsp msi etc)
in your submission. We need to be able to build and run your program therefore, please
submit your code on github as a public repository and provide us a link to clone your
repository. Your submission should contain the source code and clear instructions on how to
build, test and run the program (preferably a Readme
