<template>
    <apexchart
        type="pie"
        width="100%"
        height="100%"
        :options="chartOptions"
        :series="series"
    ></apexchart>
</template>

<script>
import { LIMIT_LABEL } from "@/utils/constants";

export default {
    name: "ChartPieComponent",
    props: {
        series: Array,
        labels: Array,
    },
    data(props) {
        return {
            chartOptions: {
                chart: {
                    type: "pie",
                },
                labels: props.labels?.map((l) => {
                    return (
                        l?.substring(0, LIMIT_LABEL) +
                        (l?.length > LIMIT_LABEL ? "..." : "")
                    );
                }),
                responsive: [
                    {
                        breakpoint: 480,
                        options: {
                            chart: {
                                width: 200,
                            },
                            legend: {
                                position: "right",
                            },
                        },
                    },
                ],
                dataLabels: {
                    enabled: true,
                    formatter: function (val) {
                        var total = props.series.reduce((a, v) => a + v, 0);
                        return `${(val / 100) * total} memo`;
                    },
                },
            },
        };
    },
};
</script>
