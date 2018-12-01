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

fn parse_input(input: &str) -> Result<Vec<i32>> {
    input
        .trim()
        .lines()
        .map(|line| {
            let num = line.trim().parse::<i32>()?;
            Ok(num)
        }).collect()
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn day02a() {}

    #[test]
    fn day02b() {}
}
