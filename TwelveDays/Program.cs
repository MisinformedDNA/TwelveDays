// Ported from https://web.archive.org/web/20081229212711/http://research.microsoft.com/en-us/um/people/tball/papers/xmasgift/final.html

string strings = "@n'+,#'/*{}w+/w#cdnr/+,{}r/*de}+,/*{*+,/w{%+,/w#q#n+,/#{l+,/n{n+,/+#n+,/#;#q#n+,/+k#;*+,/'r :'d*'3,}{w+K w'K:'+}e#';dq#'l q#'+d'K#!/+k#;q#'r}eKK#}w'r}eKK{nl]'/#;#q#n'){)#}w'){){nl]'/+#n';d}rw' i;# ){nl]!/n{n#'; r{#w'r nc{nl]'/#{l,+'K {rw' iK{;[{nl]'/w#q#n'wk nw' iwk{KK{nl]!/w{%'l##w#' i; :{nl]'/*{q#'ld;r'}{nlwb!/*de}'c ;;{nl'-{}rw]'/+,}##'*}#nc,',#nw]'/+kd'+e}+;#'rdq#w! nr'/ ') }+}{rl#'{n' ')# }'+}##(!!/";

string translate = "!ek;dc i@bK'(q)-[w]*%n+r3#l,{}:\nuwloca-O;m .vpbks,fxntdCeghiry";

///* skip -n strings (separator is /), where n is a negative value */

string skip_n_strings(int n, string s)
{
    if (n == 0)
        return s;

    if (s[0] == '/')
        return skip_n_strings(n + 1, s[1..]);
    else
        return skip_n_strings(n, s[1..]);
}

///* find the character in the translation buffer matching c and output
//   the translation */

void translate_and_put_char(char c, string trans)
{
    if (c == trans[0])
        Console.Write(trans[31]);
    else
        translate_and_put_char(c, trans[1..]);
}

void output_chars(string s)
{
    if (s[0] == '/')
        return;
    translate_and_put_char(s[0], translate);
    output_chars(s[1..]);
}

///* skip to the "n^th" string and print it */

void print_string(int n)
{
    output_chars(skip_n_strings(n, strings));
}

void inner_loop(int count_day, int current_day)
{
    if (count_day == 1)
    {
        print_string(0);               /* "On the " */
        print_string(-current_day);         /* twelve days, ranges from -1 to -12 */
        print_string(-13);     /* "day of Christmas ..." */
    }

    if (count_day < current_day)     /* inner iteration */
        inner_loop(count_day + 1, current_day);

    print_string(-25 + (count_day - 1));   /* print the gift */
}

void outer_loop(int count_day, int current_day)
{
    inner_loop(count_day, current_day);
    if (count_day == 1 && current_day < 12)  /* outer iteration */
        outer_loop(1, current_day + 1);
}

outer_loop(1, 1);
