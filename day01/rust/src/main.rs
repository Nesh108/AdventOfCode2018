/*! Day1
*   http://adventofcode.com/2018/day/1
*/

extern crate day01;

type Result<T> = std::result::Result<T, Box<std::error::Error>>;

static INPUT: &'static str = include_str!("../../input.txt");

pub fn main() {
    println!(
        "Solution 1a: {}",
        day01::solve1a(parse_input(INPUT).expect("Error Parsing Input"))
    );
    println!(
        "Solution 1b: {}",
        day01::solve1b(parse_input(INPUT).expect("Error Parsing Input"))
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
    fn day01a() {
        let ans = day01::solve1a(parse_input("+1\n-2\n+3\n+1").expect("Error Parsing Input"));
        assert_eq!(ans, 3, "Expected 3 for solve1a with `+1, -2, +3, +1`");

        let ans = day01::solve1a(parse_input("+1\n+1\n-2").expect("Error Parsing Input"));
        assert_eq!(ans, 0, "Expected 0 for solve1a with `+1, +1, -2`");

        let ans = day01::solve1a(parse_input("-1\n-2\n-3").expect("Error Parsing Input"));
        assert_eq!(ans, -6, "Expected -6 for solve1a with `-1, -2, -3`");
    }

    #[test]
    fn day01b() {
        let ans = day01::solve1b(parse_input(" +3\n+3\n+4\n-2\n-4").expect("Error Parsing Input"));
        assert_eq!(ans, 10, "Expected 10 for solve1b with `+3, +3, +4, -2, -4`");

        let ans = day01::solve1b(parse_input("-6\n+3\n+8\n+5\n-6").expect("Error Parsing Input"));
        assert_eq!(ans, 5, "Expected 5 for solve1b with `-6, +3, +8, +5, -6`");

        let ans = day01::solve1b(parse_input("+7\n+7\n-2\n-7\n-4").expect("Error Parsing Input"));
        assert_eq!(ans, 14, "Expected 14 for solve1b with `+7, +7, -2, -7, -4`");
    }
}
