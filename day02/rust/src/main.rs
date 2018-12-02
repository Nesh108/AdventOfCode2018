/*! Day2
*   http://adventofcode.com/2018/day/2
*/

extern crate day02;

type Result<T> = std::result::Result<T, Box<std::error::Error>>;

static INPUT: &'static str = include_str!("../../input.txt");

pub fn main() {
    println!(
        "Solution 2a: {}",
        day02::solve2a(parse_input(INPUT).expect("Error Parsing Input"))
    );
    println!(
        "Solution 2b: {}",
        day02::solve2b(parse_input(INPUT).expect("Error Parsing Input"))
    );
}

fn parse_input(input: &str) -> Result<Vec<&str>> {
    input.trim().lines().map(|line| Ok(line.trim())).collect()
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn day02a() {
        let ans = day02::solve2a(
            parse_input("abcdef\nbababc\nabbcde\nabcccd\naabcdd\nabcdee\nababab")
                .expect("Error Parsing Input"),
        );
        assert_eq!(ans, 12, "Expected 12 for solve2a");
    }

    #[test]
    fn day02b() {
        let ans = day02::solve2b(
            parse_input("abcde\nfghij\nklmno\npqrst\nfguij\naxcye\nwvxyz")
                .expect("Error Parsing Input"),
        );
        assert_eq!(ans, "fgij", "Expected 'fgij' for solve2b");
    }
}
