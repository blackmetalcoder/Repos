#!/bin/sh
basedir=`dirname "$0"`

case `uname` in
    *CYGWIN*) basedir=`cygpath -w "$basedir"`;;
esac

if [ -x "$basedir/node" ]; then
  "$basedir/node"  "$basedir/node_modules/sha.js/bin.js" "$@"
  ret=$?
else 
  node  "$basedir/node_modules/sha.js/bin.js" "$@"
  ret=$?
fi
exit $ret
