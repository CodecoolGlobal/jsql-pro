package com.qa.runner;

import cucumber.api.junit.Cucumber;
import org.junit.runner.RunWith;

@RunWith(Cucumber.class)
@Cucumber.Options(features = {"C:/Users/rebak/jsql-pro/src/main/java/com/qa/features"},
        glue = {"com.qa.stepDefinitions"},
//, format= {"pretty","html:test-outout"}
        monochrome = true,
        strict = true,
        dryRun = false
)
public class TestRunner {
}