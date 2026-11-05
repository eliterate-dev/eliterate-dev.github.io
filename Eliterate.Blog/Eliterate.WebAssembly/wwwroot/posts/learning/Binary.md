### What is binary?

A system for describing data that is limited to using only 2 distinct states. 

In the traditional binary number system we're going to quickly cover, that's 0 and 1, but it can be any system with exactly 2 states.

In your computer, it's "on" or "off" (or to be more precise "high" or "low").

In the old Morse code system, it was "dot" and "dash": .... . .-.. .-.. ---

Given enough space and a shared system, we can represent any information in such a binary way, we just have to rethink how we "count" things.

#### How do we do that?

Let's start by comparing it with what we're familiar with: The decimal system.

For comparison, let's dissect a random number, let's say **207**.

We'll start with decimal:

The number 207 has:
- 7 Ones
- 0 Tens
- 2 Hundreds
- 0 Thousands (and 0 of anything higher as well, but we'll discard those)

This is most easily visualized in a table:

<table>
    <tr>
        <th>Thousands</th>
        <th>Hundreds</th>
        <th>Tens</th>
        <th>Ones</th>
        <th>Total</th>
    </tr>
    <tr>
        <td>0</td>
        <td>2</td>
        <td>0</td>
        <td>7</td>
        <td>0207</td>
    </tr>
</table>

<aside>
The name "decimal" derives from the Latin word "decem", which means 10.
</aside>

As we can see, every step in this number system is x10 the last number. Ones, Tens, Hundreds, Thousands, etc.

To get "207", we go through each column in the table and multiply the number in the lower row with the number in the higher one and add them to the total:

- 0 * 1000 = 0
- 2 * 100 = 200
- 0 * 10 = 0
- 7 * 1 = 7
- Total: 207

#### Now the same in Binary

Binary, as the name implies, means we use 2 instead of the 10 we use above.

We still start with "Ones" again, but this time, to reach the next number, we multiply by 2 instead of 10.

This gives us:
- Ones
- Twos
- Fours
- Eights
- Sixteens
- Thirtytwos
- etc

That sound a bit abstract, so let's build our table again to make things clearer:

<table>
    <tr>
        <th>256</th>
        <th>128</th>
        <th>64</th>
        <th>32</th>
        <th>16</th>
        <th>8</th>
        <th>4</th>
        <th>2</th>
        <th>1</th>
    </tr>
</table>

Now let's take our 207 again and try to fit it into this table.

Unlike in decimal, where each number place can fit 0-9 of each number, because this is binary, every number place only fits exactly 0 or 1 of them.

So to dissect a number here, we can simply reverse what we did to construct our decimal number to arrive at our binary representation:

- 256 is bigger than 207, so we have "0 of 256s" -> 0, remainder: 207
- 128 fits into 207, so we subtract it and get a 1 for it -> 1, remainder: 79
- 64 fits into our remaining 79, so again we get a 1 and subtract -> 1, remainder: 15
- 32 does not fit in our remaining 15 -> 0, remainder: 15
- 16 is also still too big -> 0, remainder: 15
- 8 fits again! So we subract -> 1, remainder: 7
- 4 fits as well -> 1, remainder: 3
- 2 continues -> 1, remainder: 1
- 1 finally also fits into our leftover number -> 1, remainder: 0

Plotting this into our table we get:

<table>
    <tr>
        <th>256</th>
        <th>128</th>
        <th>64</th>
        <th>32</th>
        <th>16</th>
        <th>8</th>
        <th>4</th>
        <th>2</th>
        <th>1</th>
        <th>Total</th>
    </tr>
    <tr>
        <td>0</td>
        <td>1</td>
        <td>1</td>
        <td>0</td>
        <td>0</td>
        <td>1</td>
        <td>1</td>
        <td>1</td>
        <td>1</td>
        <td>011001111</td>
    </tr>
</table>

Nice, no?

Now we have the constructed number "11001111", which is the representation of "207" in binary (just like in decimal numbers, we can ommit any leading 0s).

#### But what if I want to turn a binary number back into decimal?

This is the neat part!

We can use the exact same system we used above to calculate a decimal number from its number parts!

Let's once again take the number we constructed above.

<table>
    <tr>
        <th>128</th>
        <th>64</th>
        <th>32</th>
        <th>16</th>
        <th>8</th>
        <th>4</th>
        <th>2</th>
        <th>1</th>
        <th>Total</th>
    </tr>
    <tr>
        <td>1</td>
        <td>1</td>
        <td>0</td>
        <td>0</td>
        <td>1</td>
        <td>1</td>
        <td>1</td>
        <td>1</td>
        <td>11001111</td>
    </tr>
</table>

- 1 * 128 = 128
- 1 * 64 = 64
- 0 * 32 = 32
- 0 * 16 = 16
- 1 * 8 = 8
- 1 * 4 = 4
- 1 * 2 = 2
- 1 * 1 = 1
- Total: 207

And that easily we have our decimal number back!

Hope this helped.