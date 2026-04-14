#![feature(step_trait)]
#![feature(trait_alias)]

mod imp;
pub mod math;

pub use imp::{LinkType, MaxValue, Num, SignNum, ToSigned};
