const fs = require('fs');
const readline = require('readline');

const REQUIRE_ARGV_LENGTH = 3;

const readFileContent = (file, onContent, encoding = "utf8") => {
    fs.readFile(file, encoding, (error, content) => {
        if (error) {
            console.error("Failed to read file:", file);
        } else {
            onContent(content);
        }
    });
}

const processLineByLine = async (inputFileName, lineReader, onDone) => {
    const fileStream = fs.createReadStream(inputFileName);
    const rl = readline.createInterface({input: fileStream, crlfDelay: Infinity});
    let lineNumber = 0;
    for await (const line of rl) {
      lineReader(line, lineNumber);
      lineNumber++;
    }
    if (onDone) onDone();
}

const startDailyChallengeWith = (handler) => {
    if (process.argv.length == REQUIRE_ARGV_LENGTH) {
        handler(process.argv[2]);
    } else {
        console.error("Usage: ", process.argv[0], process.argv[1], "<inputFile>");
    }
};

module.exports = {
    readFileContent: readFileContent,
    processLineByLine: processLineByLine,
    startDailyChallengeWith: startDailyChallengeWith
};