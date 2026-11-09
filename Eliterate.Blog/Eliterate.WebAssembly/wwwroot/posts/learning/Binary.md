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

Total: 207

And that easily we have our decimal number back!

### How do computers use this?

At the very bottom, digital information transmission is just "electricity".

Imagine the simplest electrical circuit - a power source, a simple push button and a small LED.

You push the button, electricity flows, the LED lights up. It is now "on".

You let go of the button, the circuit is broken, the LED goes dark, leaving it "off".

With this system alone, you can technically transmit any information you want. All you need is a *consensus*, a standard, for how to encode that data.

<img class="paper" style="rotate:1deg" loading="lazy" alt="A short comic on how creating a new standard usually doesn't unify any standards, but just increases the number of standards." src="../images/memes/standards_2x.png" />

For example:

You and a friend want to transmit data without speaking.

You tell that friend that every *second* you give them a "signal" by pressing or NOT pressing your button. 

Your friend can look at a clock and every second make a note of whether the light is on or off.

Their notess might end up looking a little like this:

    Off On Off Off On Off Off Off
    Off On Off Off Off On Off On
    Off On Off Off On On Off Off
    Off On Off Off On On Off Off
    Off On Off Off On On On On

...right. There's not quite enough of a consensus yet to decipher that.

All we have for now is "On" and "Off" - that alone is of course not human readable information.

So we have some defining to to.

Let's go back to our binary numbers: if we define one of these "on or off"s as... let's call it a "bit", we can take a bunch of them together to make a number larger than 0 or 1.

In that spirit, let's define 8 of these "bits" together as a unit of information. We'll call that a "byte".

The maximum number such a "byte" can hold is 255 - including 0 that's 256 different arrangements of "bits".

That's plenty for assigning a number to each of the 26 letters of the english alphabet.

We'll leave some initial slack for other symbols (don't worry about it for now) and start assigning the letters from number 65 up.

So our letters will be assigned like this:

<table>
    <tr style="font-size:9px;">
        <td>65</td>
        <td>66</td>
        <td>67</td>
        <td>68</td>
        <td>69</td>
        <td>70</td>
        <td>71</td>
        <td>72</td>
        <td>73</td>
        <td>74</td>
        <td>75</td>
        <td>76</td>
        <td>77</td>
        <td>78</td>
        <td>79</td>
        <td>80</td>
        <td>81</td>
        <td>82</td>
        <td>83</td>
        <td>84</td>
        <td>85</td>
        <td>86</td>
        <td>87</td>
        <td>88</td>
        <td>89</td>
        <td>90</td>
    </tr>
    <tr style="font-size:12px;text-align:center;">
        <td>A</td>
        <td>B</td>
        <td>C</td>
        <td>D</td>
        <td>E</td>
        <td>F</td>
        <td>G</td>
        <td>H</td>
        <td>I</td>
        <td>Y</td>
        <td>K</td>
        <td>L</td>
        <td>M</td>
        <td>N</td>
        <td>O</td>
        <td>P</td>
        <td>Q</td>
        <td>R</td>
        <td>S</td>
        <td>T</td>
        <td>U</td>
        <td>V</td>
        <td>W</td>
        <td>X</td>
        <td>Y</td>
        <td>Z</td>
    </tr>
</table>

That's our "consensus".

Now let's translate the first line of our message again:

    Off On Off Off On Off Off Off

Would give us

    0 1 0 0 1 0 0 0

Run that back through our deconversion algorithm and we get:

- 0 * 128 = 0
- 1 * 64 = 64
- 0 * 32 = 0
- 0 * 16 = 0
- 1 * 8 = 8
- 0 * 4 = 0
- 0 * 2 = 0
- 0 * 1 = 0

Total: 72

In our table, "72" corresponds to "H", so that's our first letter!

Can you translate the rest of the message?

Solution:
<span class="spoiler">72 69 76 76 79 -> H e l l o</span>

Now a computer doesn't need a button to press, and it doesn't need a to observe a light, but that aside, they do basically the same thing - just much, much faster.

Instead of "a light", a digital input simply measures if there **IS** electricity or none.

No electricity gets registered as a 0 or "low", and when there is a voltage over a certain threshold, it registers a 1 or "high".

That's it. That's the basics of how a computer turns information into ones and zeroes, sends them to another computer, which then turns it back into human readable information.

The "consensus table" we used above is called [ASCII](https://en.wikipedia.org/wiki/ASCII) - it's an old standard based on 8 bits, but it's still useable.

Congrats. You know this now.