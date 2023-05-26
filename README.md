# Drink-Book-Data-Entry-App

This application is purpose-made for entering in drinks from my old bar.

### Some Backstory

Before covid, I used to own and run a bar. I've been going through the process of archiving all the old custom cocktail recipes it used to have. Having been running a Patreon for the archive project, hoping to create a bar book with hundreds of recipes, my first thought was just to toss them all into a PDF. 

When I started this conversion project seeing the potential of not just copy-pasting everything into a document, slapping print to pdf, and calling it a complete project. When I started to look at the differences in drinks and the actual data, I realized I was doing a massive injustice to this all. 

So why XML and not just slap it all into SQL and go? Well, I didn't know what kind of database I wanted to use for this; I also thought about a Nosql document database for a bit. When it came down to the wire, I needed to start the data entry (and glad I did, cause it took a month). I landed on XML because it's a great way to transfer data from one form to the other in my limited experience. Why not JSON? To be truthful, I don't know; I just was like, "I'll do this in XML!" and wrote the data entry app. After data entry, I figured I could build Python scrips to ETL this into its final form.

I created this software using .net MAUI specifically for a former employee of mine who is a data entry subcontractor. This employee has difficulty finding work due to their injuries, so I tailored the software to their preferred method of data entry. Through several iterations and feedback from the employee, the software was optimized for efficient data entry.
