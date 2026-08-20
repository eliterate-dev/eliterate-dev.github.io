### QR Codes are not scary

I mean, they're not entirely without danger, sure. Just like any link you'd get in an email, do not click (or scan) anything shady.

But any QR scanner worth it's salt will display the URL you're about to open before opening it - always make sure it's one you marginally trust.

Anyways, I find that usually people are afraid of things they don't understand, so let's try to demystify QR codes.

#### What is a QR code anyways?

QR stands for "quick response". 

Unless that comes up as an answer on "Who wants to be a millionaire?" though, you can forget that again right away. It's not important and doesn't actually tell us anything useful.

What QR codes actually are, is the logical progression up from their 1-dimensional counterpart - the barcode.

#### A not so short tangent on Barcodes

While QR codes are very common nowadays, barcodes are certainly still ubiquitous. I'm sure I don't have to explain what a barcode **is**. 

Every product in a store has one. You or your cashier scans them. Product gets added to your bill.

They work on a very simple principle: You have a line. A thick line. You could call it a rectangle, I guess. But it's a line. Parts of that line are black, other parts are white.

Anyone who's ever had anything to do with programming or just computers in general might spot something familiar in that.

That's right, t's a binary system!

<a href="posts/binary_counting_systems">
<aside>
If you don't know about binary, there is a short post about the topic you can read by clicking on this box!
</br>
It'll help a lot in understanding the rest of this post.
</aside>
</a>

We can't naively take a number in its binary representation and make a barcode out of it. The whitespace distribution would be totally whack.

Imagine: if we wanted to represent, let's say 17 in a 12 digit number where we use half a byte (4 bits) per digit in pure binary (enough to represent 0-9), it would be 
    0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0001 0111.

Now that would be a confusing amount of *empty* in your barcode, wouldn't it?

**The most common standard** for barcodes, UPC (Universal Product Code), instead does the following:

<img class="paper image" style="rotate:1deg" loading="lazy" alt="An image of the table of encodings." src="../images/misc/barcode_encoding.png" credit="Wikipedia" />

Like the image shows, each number was assigned a 7 bit sequence and its inverse (e.g. 0011001 & 1100110 for number "1").

A barcode is then constructed from these 7 bit segments + so called "guard patterns" on either side and the middle - these are the usually slightly longer bars you see in most barcodes.

They are always either Black-White-Black on the ends or White-Black-White-Black-White in the middle.

These guard patterns help the scanner to know where to start and stop reading. Since they're always the same, it's easy to look for them.

So for example, a barcode representing a 12 digit number is constructed like this:

- Start guard pattern (3 bars)
- Left side: 6 digits as the assigned 7 bit sequence (6 * 7 bars)
- Middle guard pattern (5 bars)
- Right side: 6 digits as the assigned inverse 7 bit sequence (6 * 7 bars)
- End guard pattern (3 bars)

For a total of 95 bars - that's all a barcode really is. 95 thin black or white bars.

To our human eyes, it's of course difficult to distinguish where one black or white bar ends and another begins, but for a scanner that's no problem.

As this most common type of barcode can encode 12 digits, it's obviously enough to assign a unique number to a lot of products (1 trillion products, to be exact).

That was enough for us for a long time.

#### Stepping up the dimensions

<img class="paper image" style="rotate:-1deg" loading="lazy" alt="An image of a Go board." src="../images/misc/go_board.jpg" />

Well, <a href="https://en.wikipedia.org/wiki/Masahiro_Hara" target="_blank">some Japanese dude</a> thought that just digits is boring.

The folklore is, that as he was thinking about the problem of how to encode more information in a space saving way, he came across and was inspired by a Go board.

Such tales are usually apocryphal (like the apple falling on Newton's head (yes, I'm sorry if you found out this way, but that never happened)), but as I don't see the claims overly aggrandized as they usually are, and Go is certainly popular in Japan, this one seems plausible to me.

Well, whether it's true or not, the new QR code standard resulting from his invention is certainly a big improvement over barcodes.

Let's just do some head math: If the one dimensional barcodes encoded 95 bits on a line, then in a square that's already 95^2^ bits!

Of course, that's once again a naive approach. Even in 2 dimensions, some space needs to be sacrificed for ways to show scanners *where* to scan.

However, how much data a QR code can hold is actually even less straight forward.

#### Versions

The current standard is split into 40 "Versions". When creating a QR code you define what version you want to use from 1 to 40.

Calling it "Version" is a misnomer, in my opinion, as it simply determines their size. Sadly, naming is not up to me.

At least that size calculation is very straightforward:

The length of a side of a QR code square is simply 4 * "Version Number" + 17.

<table>
    <tr>
        <th>Version</th>
        <th>Side</th>
        <th>+ 17</th>
    </tr>
    <tr>
        <td>1</td>
        <td>4</td>
        <td>21</td>
    </tr>
    <tr>
        <td>2</td>
        <td>8</td>
        <td>25</td>
    </tr>
    <tr>
        <td>3</td>
        <td>12</td>
        <td>36</td>
    </tr>
    <tr>
        <td>...</td>
        <td>...</td>
        <td>...</td>
    </tr>
    <tr>
        <td>40</td>
        <td>160</td>
        <td>177</td>
    </tr>
</table>

#### QR's "Guard patterns"

Now, if we again approach this naively, it would seem that the total information in bits in a square is simply that side length... well squared. So for a version 1 QR code that would be 441 (21x21), for a version 40 QR code it would be 31329 (177x177)!

However, just like with the barcode's guard patterns, we need to give the scanners a way to recognize where they should start scanning and decoding the data.

If you've ever looked at a QR code, I'm sure you have noticed the big ▣ looking blocks in the corners. That's what they are for. They tell your scanner "Hey, this is really a QR code and you can scan between these squares."

All QR codes have the 3 obvious squares in the top right, top left and bottom left corners. However higher version QR codes also have additional, smaller such "guard pattern squares" further inside the code, to make sure your scanner gets all the data.

So with these guard patterns taking up some space, what's the *actual* amount of data you can store in a QR code?

Well, there's still one more caveat we have to get to before that.

#### Error Correction

Because we now have 2 dimensions, we can do some fun little math on it to correct errors within the data!

The actual math is fascinating, but a bit outside the scope of this post (and, to be honest, outside my teaching skill) if you want to learn the details, read up on [Reed-Solomon error correction](https://en.wikipedia.org/wiki/Reed%E2%80%93Solomon_error_correction). 

<img class="paper image" style="rotate:1deg" loading="lazy" alt="A nonogram number puzzle and its solution." src="../images/misc/nonogram.png" />

If I were to abstract it to the point that a proper mathematician would probably like to strangle me, I like to imagine it a bit like a [Nonogram](https://en.wikipedia.org/wiki/Nonogram).


### Make your own QR codes!

This is a companion piece to the QR generator tool I have added to this site!

Go and make some QR codes of your own.

<a href="https://eliterate.blog/tools/qr" target="_blank">Link to tool</a>