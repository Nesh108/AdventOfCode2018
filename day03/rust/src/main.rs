/*! Day3
*   http://adventofcode.com/3018/day/3
*/

extern crate day03;

type Result<T> = std::result::Result<T, Box<std::error::Error>>;

static INPUT: &'static str = include_str!("../../input.txt");

pub fn main() {
    let (answer, overlapped_ids) = day03::solve3a(parse_input(INPUT).expect("Error Parsing Input"));

    println!("Solution 3a: {}", answer);
    println!(
        "Solution 3b: {}",
        day03::solve3b(overlapped_ids).expect("No overlapping IDs found")
    );
}

fn parse_input(input: &str) -> Result<Vec<&str>> {
    input.trim().lines().map(|line| Ok(line.trim())).collect()
}
