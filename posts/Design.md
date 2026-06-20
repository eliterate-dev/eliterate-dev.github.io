### Pure CSS

Although I have some <a href="https://getbootstrap.com/">Bootstrap</a> experience and I think it's a fine framework, I decided against using it for this project.

CSS has become quite powerful over the decades, and far too many of us still don't utilize it to the fullest potential.

So to not use any framework as a crutch, I'm writing all the CSS for this project myself.

Since I have decided on the name "Eliterate", I chose to go with a book theme for the site.

...that makes sense or something, right?

<div class="sticker" style="rotate:9deg;" role="presentation">📂</div>

#### Home

What's at the start of a book?

That's right! The cover: The thing you judge a book by.

I imagine this website kind of like a personal notebook. So I tried to style it a bit like I would such a notebook.

That means stickers and probably some scribbles. My notebooks were messy...

The "tagline" is randomly selected from a few songquotes in a .json file. Since my taste in music is all over the place I made sure to put the source in the bottom right corner of the page.

Finally, because I felt like I should give some sort of short introduction, I decided to put a flashcard with an intro loosely on the top.

Good enough.

#### The "Book"

It may be easily overlooked, but you might have noticed the book on the home and credit pages is kinda 3d.

So what? You may think. It's a choppy image of a book.

Well... it's not an image. It's a 3d object created out of pure HTML and CSS!

It's a completely silly construction - only an idiot would put in so much work for a throwaway decorative object most people will overlook.

Well, luckily for us, I'm that idiot.

Let me walk us through how it works.

##### 3D in CSS

The option for 3-dimensionality is built into CSS. Even most beginners will be familiar with the z-index - a value on positioned elements that lets you move one to the "front" of another.

However, in the animation and transformation properties of CSS, you can do so much more!

Give your elements the `transform-style: preserve-3d;` property, and you're halfway there.

Now you can make a rectangle in html and then move it around in 3d space on your page!

	transform: rotateX(10deg) rotateY(10deg) rotateZ(10deg);
	translate: 10px 10px 10px;

That forms the basis for all the 3d objects I have created for this site.

##### Cuboids

You can build a lot of real world objects in a "good enough" fashion with a bunch of boxes. Minecraft built an entire empire based on that.

So I decided to build a component that is basically a brick. 

To get started, I once again went to ~~steal some code~~ get inspired.

I found [this handy write up by Julia Miocene](https://miocene.io/post/3d-cube-with-css). It was the perfect starting point I needed and I encourage everyone to check it out. It's great.

It was, in concept, almost exactly what I needed. However, I had a few requirements it didn't statisify, so as per usual, I had to write my own implementation (I am the worst code thief imaginable).

- I wanted the ::before and ::after pseudo elements of the bottom to handle the left and back "wall" and the ones on top to handle the right and front.
- Just rotating the 4 surrounding walls up or down respectively wasn't quire good enough for me. I wanted to potentially display text or textures on the sides, which I wanted to align - so I had to rotate and move them a bit more than the example.

##### Assembling a book

Well now that I have Cuboids, a book is easy: It's just 4 rectangles: A cover, the back, the spine and the pages.

Minor playing around with rotations so that I can write on the spine.

#### Flashcards

Flashcards were initially just a way to have multiple links to posts on one webpage.

Should it be a chapter page? It would make sense, but I already used that for the navigation.

Besides, a post selection should have more info than just the name of the post. Maybe a short description? Tags?

No, a chapter selection would be too limited.

Libraries use small cards and the [Dewey Decimal System](https://en.wikipedia.org/wiki/Dewey_Decimal_Classification) to quickly find books anywhere in the shelves.

Taking that for inspiration I decided for some sort of a "card" look.

I'm technically showing the location of "pages" not "books" on them, but let's not sweat the details. I like how it looks, it fits the theme and that's all that matters.

After another google image binge for creative stimulation (and halfway into an attempt of writing my own Dewey Decimal categorizer), I decided on a simple flashcard design instead.

The result is what you see on top of the notebook on the ["Home"](/home) and ["Posts"](/posts) pages.

They're simple and look nice when decorated with stickers.

I then wrote a small injected service which can read a metadata Json file and generate the cards based on that, complete with sticker, tags and link to the post in question.

Structurally, the cards are inspired by [Bootstrap cards](https://getbootstrap.com/docs/4.0/components/card/). A component I really liked when using Bootstrap. Though of course, entirely implemented by me.

#### Stickers

I like stickers. They're a nice, simple medium to give drab, mass produced items a bit of individuality. You should see my laptop or my travelling suitcase!

So obviously I wanted stickers on my digital book and my posts.

The "tag stickers" on the cards kinda naturally evolved out of my first idea for tags - simple "word boxes" with a white border to give it that sticker look.

Taking that thought to the next level, I first tried to implement some pngs with white outlines. It worked fine, but putting dozens of pngs on every page grated on my optimisation sensibilities, so I searched for an alternative.

The concept of using emojis as stickers was then ~~blatantly stolen~~ borrowed from the very creative and inspiring <a href="https://eev.ee/">Evelyn Woods</a>, who has mastered CSS to an astonishing level. I mean, check out those ripped paper and punch-hole masks...

I wrote my own implementation of them though. I got manners and shit.

It's essentially just few text-shadows and filters. I could have probably done with just one of the two, but I felt I got the most convincing effect by using both.

I grab my unicode emojis from <a href="https://symbl.cc/">Symbl</a> - my go to resource for Unicode, though basically any unicode character list will do.

#### Navigation

I went through a few iterations of navigation designs before I settled on the current one.

At first I wanted the Nav menu to be a book spine, but you don't really put "chapters" or similar on a spine - not to mention it didn't really fit into the mobile view.

Thinking of pages and content as "chapters" (although not exactly correct) led me to just style it as a book's chapter page.

How and why one would keep the book's chapter page constantly open while reading the book are questions I pointedly decided to ignore forever.

I went through a lot of images on google searching for a book content page I liked and eventually landed on the style of [chapter name.....page number] I use now.

A simple call to the string function `"ChapterName".PadRight(20, '.')` allows to keep the number of characters consistent between "chapter names" and dots.

However, just having a consistent number of characters does not mean every line is of consistent length. In most fonts, letters like "i" or "l" do not take up as much space as an "m", for example.

Thankfully, there are [monospace fonts](https://en.wikipedia.org/wiki/List_of_monospaced_typefaces), which, as their name suggests, exist exactly to fix this problem. They make sure every character used in the font has the same width. So I applied one of those to the nav links and now all my lines (which all have the same amount of characters thanks to `.PadRight(20, '.')`) are of equal width.

#### Posts (Pages)

<div class="sticker" style="rotate:-8deg;" role="presentation">📝</div>

In keeping with the book theme, every blog post is going to be its own "page" of the book.

Apart from the small styling on the borders there isn't much complicated about pages.

Like all textures on this website, the "notebook" texture comes from [Transparent Textures](https://www.transparenttextures.com/), which is a great resource for people who don't have the skills to make textures themselves (like me).

A service injected through [dependency injection](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection/overview) gets the .md file containing the post data, after which I use [Markdig](https://github.com/xoofx/markdig), a common C# Markdown library to convert the markdown into HTML code.

#### Pictures

There are different styles of how I chose to display images within my "pages".

I'm a millenial and basic af, so I like polaroids and they also fit the scrapbook / notebook look of the project very well, so naturally, that's one style I wanted to emulate.

It's pretty simple pure CSS, just some padding and some borders, but I think it looks good.

I'm using a different font on the polaroids, to give them a bit more of a handwritten feel - though to be honest it's way more legible than my handwriting would be.

For other images like memes I wanted to post, I decided to go with a very simple "paper" look. Like I printed the meme and glued it into my book. Damn... Imagine actually printing a meme. Funny thought.

#### Tags

I wanted a way to filter posts, so tags were the obvious path to take.

However, I had a few requirements:

- They should be unobtrusive
- They should be pretty and colorful
- However, that color should be consistent for each tag

That last requirement was a small struggle. I had the idea for sticky notes already, so I knew I wanted them pastel.

Assigning them a random color is easy, however if I wanted to keep the color consistent so they are easily recognizable by color, I had to think of something else.

The solution was calculating the color from the tag name:

    var hue = tag.Sum(c => c) % 360

The `.Sum()` method used on a string treats the string as a list of `char` and as `char` implicitly converts to `int` types in C#, it can be summed.

This sum, `mod 360`, gives me a consistent hue on the color circle. Full saturation and a high "lightness" value in the `hsl()` css color scheme ensure it's a nice pastel.

    style="background-color: hsl(@hue, 100% 80%)"

##### Tag Stickers

At first I simply styled all tags as stickers.

They did not have any functionality yet at that point, and I thought I'd use them more as a gag (like the "Why not?" tag at the top of this page).

<div class="sticker" style="rotate:14deg;" role="presentation">📎</div>

I quickly decided however, that they would make for a good way to filter posts a bit. Not that there were any posts to filter yet, but I do often suffer from premature optimization.

So I made an easy to use component out of the stickers and added a link to them.

##### Tag "Notes"

For content pages I went for the little sticky-notes you put in a book to remember where important stuff is. I liked the look of that.

It was a tad tedious to have to place the tags at the bottom of the post (you can see that by using inspect on this page) and then fix them to the top with `position:absolute;`, but I felt like prioritzing logical dom[^1] and tab order over small inconvinences for myself.

#### The idea board

The spark for the ["plans"](/plans) page came partially from real world post boards in my area, and partially again from [Evelyn Woods](https://eev.ee/), who's whole home page is basically that concept. Though as before, the implementation is entirely my own.

Brick, cork and paper textures are, like all my textures, from [Transparent Textures](https://www.transparenttextures.com/), wheras the pins are just a repurposed form of the "emojis as stickers" concept - they're pin emojis.

### Any questions? Anything unclear?

The entire code is open source and viewable [here](https://github.com/eliterate-dev/eliterate-dev.github.io).

Feel free to fork or copy anything you want. 

If you find an error (not unlikely) or simply want to shoot me a question, send me an email @ [contact@eliterate.blog](mailto:contact@eliterate.blog)!

Can't promise I'll reply right away, but I'll get to it eventually.

Let's make the web weird again.

### Footnotes

[^1]: DOM or Document Object Model is the "layout" of the html page not as it's being rendered, but as it's actually written. Most of the time, the two are the same, but sometimes it makes sense to place something where it's not in the DOM to help screenreaders, for example. 