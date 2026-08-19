## What is binary?



A system for conveying data with only 2 distinct states. In the traditional binary number system, that's 0 and 1, but it can be any system with exactly 2 states.

In your computer, it's "on" or "off" (or to be more precise "high" or "low").

For our purpose today, it's "black" or "white".

Given enough space, we can represent any information in such a binary system, we just have to rethink how we "count" things.

Let's compare it with what we're familiar with: The decimal system.

For comparison, let's dissect the number **107**:

The number 107 has:
- 0 Thousands
- 1 Hundreds
- 0 Tens
and 
- 7 Ones.

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
        <td>1</td>
        <td>0</td>
        <td>7</td>
        <td>0107</td>
    </tr>
</table>

As we can see, every step in this number system is x10 the last number. Ones, Tens, Hundreds, Thousands, etc.

Binary, as the name implies, instead increases x2, instead of x10.

That sound a bit abstract, so let's build our table again to make things clearer:

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
        <td>0</td>
        <td>1</td>
        <td>1</td>
        <td>0</td>
        <td>1</td>
        <td>0</td>
        <td>1</td>
        <td>1</td>
        <td>01101011</td>
    </tr>
</table>

Now we have 
