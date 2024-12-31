<template>
    <ag-charts :options="options" />
</template>

<script>
import { ref } from "vue";
import { AgCharts } from "ag-charts-vue3";
import "ag-charts-enterprise";

import Topology from "./VueAGMaps/topology.js";

export default {
    name: "VueAGMapsComponent",
    props: {
        data: Array,
    },
    components: {
        "ag-charts": AgCharts,
    },
    setup(props) {
        const options = ref({
            data: props.data,
            topology: Topology,
            series: [
                {
                    type: "map-shape-background",
                },
                {
                    type: "map-shape",
                    title: "Memorandums by Country",
                    idKey: "name",
                    colorKey: "value",
                    colorName: "No. of Memorandums",
                },
            ],
            gradientLegend: {
                enabled: true,
                position: "right",
                gradient: {
                    preferredLength: 200,
                    thickness: 5,
                },
                scale: {
                    label: {
                        fontSize: 16,
                        formatter: (p) => p.value + " Memo",
                    },
                    interval: {
                        step: 1,
                    },
                },
            },
        });

        return {
            options,
        };
    },
};
</script>
